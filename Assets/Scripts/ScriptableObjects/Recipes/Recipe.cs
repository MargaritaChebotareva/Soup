using Assets.Scripts.ScriptableObjects.Ingredients;
using System;
using UnityEngine;

namespace Assets.Scripts.ScriptableObjects.Recipes
{
    [Serializable]
    public class Recipe
    {
        [SerializeField] private string name;
        [SerializeField] private int price;
        [SerializeField] IngredientsList items;

        public string Name => name;
        public int Price => price;

        public void SetIngredientsSet(IngredientTypeSet types)
        {
            items.SetTypes(types);
        }

        public Core.Entities.Ingredient[] GetIngredients()
        {
            return items.GetIngredients();
        }
    }
}