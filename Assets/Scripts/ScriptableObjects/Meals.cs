using Assets.Scripts.ScriptableObjects.Common;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.ScriptableObjects
{
    [CreateAssetMenu(menuName = "Scriptable Objects/Meals", fileName = "Meals", order = 4)]
    public class Meals : ScriptableObject
    {
        [SerializeField] private Ingredients ingredients;
        [SerializeField] private List<Meal> meals = new();

        public void OnValidate()
        {
            if (ingredients == null) return;
            foreach (var item in meals)
            {
                item.SetIngredientsForEditor(ingredients);
            }
        }

        public Core.Entities.Recipe[] GetRecipes()
        {
            List<Core.Entities.Recipe> result = new(meals.Count);
            foreach (var item in meals)
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

        public Meal[] GetPrefabs()
        {
            return meals.ToArray();
        }
    }
}