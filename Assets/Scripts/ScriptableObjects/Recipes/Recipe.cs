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

        public void SetIngredientsSet(IngredientTypeSet types)
        {
            items.SetTypes(types);
        }
    }
}