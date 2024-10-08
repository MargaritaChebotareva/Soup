using Assets.Scripts.Core.Entities;
using Assets.Scripts.Core.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Assets.Scripts.Data.InMemory
{
    public class IngredientRepository : IIngredientRepository
    {
        private Dictionary<int, Ingredient> ingredients = new();
        private Dictionary<string, IngredientType> ingredientTypes = new();

        public Ingredient GetIngredient(int id)
        {
            if (ingredients.ContainsKey(id))
            {
                return ingredients[id];
            }
            return null;
        }

        public Ingredient[] GetIngredients(string name)
        {
            return ingredients.Where(x => x.Value.Name == name).Select(x => x.Value).ToArray();
        }

        public void UpdateIngredient(Ingredient ingredient)
        {
            ingredients[ingredient.Id] = ingredient;
        }

        public void AddIngredient(string name, Owner owner)
        {
            int max = 0;
            if (ingredients.Count > 0) max = ingredients.Keys.Max();
            max++;
            var ingredient = new Ingredient(max, name);
            ingredient.SetOwner(owner);
            ingredients.Add(max, ingredient);
        }

        public void AddIngredients(Ingredient[] items, Owner owner)
        {
            for (int i = 0; i < items.Length; i++)
            {
                AddIngredient(items[i].Name, owner);
            }
        }

        public Ingredient[] GetIngredients()
        {
            return ingredients.Values.ToArray();
        }

        public void Remove(int id)
        {
            ingredients.Remove(id);
        }

        public void RemoveAny(string name)
        {
            var id = GetIngredients(name).Last().Id;
            ingredients.Remove(id);
        }

        public void AddIngredientTypes(IngredientType[] types)
        {
            foreach (var item in types)
            {
                if (!ingredientTypes.ContainsKey(item.Name))
                {
                    ingredientTypes.Add(item.Name, item);
                }
            }
        }

        public IngredientType[] GetIngredientTypes()
        {
            return ingredientTypes.Values.ToArray();
        }

        public IngredientType GetIngredientType(string name)
        {
            return ingredientTypes[name];
        }
    }
}
