using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.ScriptableObjects.Ingredients;

namespace Assets.Scripts.ScriptableObjects.Recipes
{
    [CreateAssetMenu(fileName = "RecipeSet", order = 2)]
    public class RecipeSet : ScriptableObject
    {
        [SerializeField] private IngredientTypeSet ingredients;
        [SerializeField] private List<Recipe> recipes = new List<Recipe>();

        public void OnValidate()
        {
            if (ingredients == null) return;
            foreach (var item in recipes)
            {
                item.SetIngredientsSet(ingredients);
            }
        }
    }
}