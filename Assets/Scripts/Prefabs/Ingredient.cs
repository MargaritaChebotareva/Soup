using Assets.Scripts.Controllers;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.Prefabs
{
    public class Ingredient : MonoBehaviour, IPointerClickHandler
    {
        private IngredientController ingredientController;
        private int id;
        public void Init(IngredientController ingredientController, int id)
        {
            this.ingredientController = ingredientController;
            this.id = id;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            ingredientController.ClickOnIngredient(id);
        }
    }
}