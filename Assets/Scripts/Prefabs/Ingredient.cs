using Assets.Scripts.Controllers;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace Assets.Scripts.Prefabs
{
    public class Ingredient : MonoBehaviour, IPointerClickHandler
    {
        private IngredientController ingredientController;
        private int id;

        [Inject]
        public void Inject(IngredientController ingredientController)
        {
            this.ingredientController = ingredientController;
        }

        public void Init(int id)
        {
            this.id = id;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            ingredientController.ClickOnIngredient(id);
        }

        public bool IsEqualId(int id)
        {
            return this.id == id;
        }

        public void SetAsUser()
        {
            transform.position = new Vector3(1, 0, 0);
        }

        public void SetAsNone()
        {
            transform.position = new Vector3(-1, 0, 0);
        }
    }
}