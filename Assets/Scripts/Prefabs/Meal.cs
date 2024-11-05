using Assets.Scripts.Controllers;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace Assets.Scripts.Prefabs
{
    public class Meal : MonoBehaviour, IPointerClickHandler
    {
        private MealController mealController;
        private int id;

        [Inject]
        public void Inject(MealController mealController)
        {
            this.mealController = mealController;
        }
        public void Init(int id)
        {
            this.id = id;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            mealController.ClickOnMeal(id);
        }
    }
}