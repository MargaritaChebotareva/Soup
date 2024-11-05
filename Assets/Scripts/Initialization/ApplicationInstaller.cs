using Assets.Scripts.Controllers;
using Assets.Scripts.Core.Output;
using Assets.Scripts.Core.Repositories;
using Assets.Scripts.Core.UseCases;
using Assets.Scripts.Data.InMemory;
using Assets.Scripts.Initialization.Commands;
using Assets.Scripts.Presenters;
using Assets.Scripts.Services;
using Zenject;

namespace Assets.Scripts.Initialization
{
    internal class ApplicationInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<ApplicationInitializer>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<ApplicationInitializerLog>().AsSingle().NonLazy();

            BindInitialSteps();
            BindRepositories();
            BindUseCases();
            BindServices();
            BindControllers();
            BindPresenters();
        }

        private void BindInitialSteps()
        {
            Container.BindInterfacesAndSelfTo<StorageLoader>().AsSingle();
            Container.BindInterfacesAndSelfTo<RepositoryInitializer>().AsSingle();
            Container.BindInterfacesAndSelfTo<SceneBuilder>().AsSingle();
        }

        private void BindRepositories()
        {
            Container.Bind<IUserRepository>().To<UserRepository>().AsSingle();
            Container.Bind<IIngredientRepository>().To<IngredientRepository>().AsSingle();
            Container.Bind<IMealRepository>().To<MealRepository>().AsSingle();
        }

        private void BindUseCases()
        {
            Container.Bind<Initialize>().AsSingle();
            Container.Bind<BuyIngredient>().AsSingle();
            Container.Bind<PrepareMeal>().AsSingle();
            Container.Bind<SellMeal>().AsSingle();
        }

        private void BindServices()
        {
            Container.Bind<IngredientFacade>().AsSingle();
            Container.Bind<MealFacade>().AsSingle();
        }

        private void BindControllers()
        {
            Container.Bind<IngredientController>().AsSingle();
            Container.Bind<LeverController>().AsSingle();
            Container.Bind<MealController>().AsSingle();
        }

        private void BindPresenters()
        {
            Container.Bind<IPresenter>().To<Presenter>().AsSingle();
        }
    }
}
