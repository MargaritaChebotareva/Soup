using Assets.Scripts.Core.Entities;
using Assets.Scripts.Core.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Assets.Scripts.Data.InMemory
{
    public class RecipeRepository : IRecipeRepository
    {
        private Dictionary<string, Recipe> recipes = new();
        private Dictionary<int, Meal> meals = new();

        public void AddMeal(Recipe recipe)
        {
            int max = meals.Keys.Max();
            max++;
            var meal = new Meal(max, recipe.Name);
            meals.Add(max, meal);
        }

        public void AddRecipes(Recipe[] items)
        {
            for(int i = 0; i < items.Length; i++)
            {
                if(!recipes.ContainsKey(items[i].Name))
                {
                    recipes.Add(items[i].Name, items[i]);
                }
            }
        }

        public Meal GetMeal(int id)
        {
            if (meals.ContainsKey(id))
            {
                return meals[id];
            }
            return null;
        }

        public int GetMealCount()
        {
            return meals.Count();
        }

        public Meal[] GetMeals()
        {
            return meals.Values.ToArray();
        }

        public Recipe GetRecipe(string name)
        {
            if (recipes.ContainsKey(name))
            {
                return recipes[name];
            }
            return null;
        }

        public Recipe[] GetRecipes()
        {
            return recipes.Values.ToArray();
        }

        public void RemoveMeal(int id)
        {
            meals.Remove(id);
        }

        public void UpdateRecipe(Recipe recipe)
        {
            recipes[recipe.Name] = recipe;
        }
    }
}
