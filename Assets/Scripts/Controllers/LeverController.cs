using Assets.Scripts.Core.UseCases;
using UnityEngine;

namespace Assets.Scripts.Controllers
{
    public class LeverController
    {
        private PrepareMeal prepareMeal;

        public LeverController(PrepareMeal prepareMeal)
        {
            this.prepareMeal = prepareMeal;

            Debug.Log($"{nameof(LeverController)} was created");
        }

        public void ClickOnLever()
        {
            prepareMeal.Execute();
        }
    }
}