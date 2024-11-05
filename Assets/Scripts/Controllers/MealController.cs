using Assets.Scripts.Core.UseCases;
using Assets.Scripts.Core.UseCases.Requests;
using UnityEngine;

namespace Assets.Scripts.Controllers
{
    public class MealController
    {
        private SellMeal sellMeal;

        public MealController(SellMeal sellMeal)
        {
            this.sellMeal = sellMeal;
            Debug.Log($"{nameof(MealController)} was created");
        }

        public void ClickOnMeal(int id)
        {
            sellMeal.Execute(new SellMealRequest(id));
        }
    }
}