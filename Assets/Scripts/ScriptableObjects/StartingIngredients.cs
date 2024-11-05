using Assets.Scripts.ScriptableObjects.Common;
using UnityEngine;

namespace Assets.Scripts.ScriptableObjects
{
    [CreateAssetMenu(menuName = "Scriptable Objects/StartingIngredients", fileName = "StartingIngredients", order = 3)]
    public class StartingIngredients : ScriptableObject
    {
        [SerializeField] private Ingredients ingredients;
        [SerializeField] private IngredientsList startingItems;

        public void OnValidate()
        {
            if (ingredients != null)
            {
                startingItems.SetIngredientsForEditor(ingredients);
            }
        }

        public Core.Entities.Ingredient[] GetIngredients()
        {
            return startingItems.GetIngredients();
        }
    }
}