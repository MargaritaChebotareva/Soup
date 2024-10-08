using System;
using UnityEngine;

namespace Assets.Scripts.ScriptableObjects.Ingredients
{
    [Serializable]
    public class IngredientType
    {
        [SerializeField] private string name;
        [SerializeField] private int pricePerUnit;

        public string Name => name;
        public int Price => pricePerUnit;
    }
}