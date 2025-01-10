using Assets.Scripts.Initialization.Commands;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Initialization
{
    internal class ShoppingSceneInstaller : MonoInstaller
    {
        [SerializeField] private ItemScatterer itemScatterer;

        public override void InstallBindings()
        {
            BindInitialSteps();
        }

        private void BindInitialSteps()
        {
            Container.BindInstance(itemScatterer);
            // TODO: need to call constructor (NonLazy)
            Container.BindInterfacesAndSelfTo<SceneBuilder>().AsSingle().NonLazy();
        }
    }
}
