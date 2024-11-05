using System;
using UnityEngine;

namespace Assets.Scripts.ScriptableObjects.Common
{
    [Serializable]
    public class Meal
    {
        [SerializeField] private string name;
        [SerializeField] private int price;
        [SerializeField] IngredientsList items;
        [SerializeField] private Prefabs.Meal prefab;

        public string Name => name;
        public int Price => price;
        public Prefabs.Meal Prefab => prefab;

        public void SetIngredientsForEditor(Ingredients ingredients)
        {
            items.SetIngredientsForEditor(ingredients);
        }

        public Core.Entities.Ingredient[] GetIngredients()
        {
            return items.GetIngredients();
        }
    }
}