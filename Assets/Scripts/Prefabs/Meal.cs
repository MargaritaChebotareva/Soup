using Assets.Scripts.Controllers;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.Prefabs
{
    public class Meal : MonoBehaviour, IPointerClickHandler
    {
        private MealController mealController;
        private int id;
        public void Init(MealController mealController, int id)
        {
            this.mealController = mealController;
            this.id = id;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            mealController.ClickOnMeal(id);
        }
    }
}