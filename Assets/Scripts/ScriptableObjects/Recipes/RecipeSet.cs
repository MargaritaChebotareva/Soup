using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.ScriptableObjects.Ingredients;

namespace Assets.Scripts.ScriptableObjects.Recipes
{
    [CreateAssetMenu(fileName = "RecipeSet", order = 2)]
    public class RecipeSet : ScriptableObject
    {
        [SerializeField] private IngredientTypeSet ingredients;
        [SerializeField] private List<Recipe> recipes = new ();

        public void OnValidate()
        {
            if (ingredients == null) return;
            foreach (var item in recipes)
            {
                item.SetIngredientsSet(ingredients);
            }
        }

        public Core.Entities.Recipe[] GetRecipes()
        {
            List<Core.Entities.Recipe> result = new(recipes.Count);
            foreach (var item in recipes)
            {
                var ingredients = item.GetIngredients();
                var IngredientAmounts = new Core.Entities.IngredientAmount[ingredients.Length];
                for (int i = 0; i < IngredientAmounts.Length; i++)
                {
                    IngredientAmounts[i] = new(ingredients[i].Name, 1);
                }
                var recipe = new Core.Entities.Recipe(item.Name, IngredientAmounts, item.Price);
                result.Add(recipe);
            }
            return result.ToArray();
        }
    }
}