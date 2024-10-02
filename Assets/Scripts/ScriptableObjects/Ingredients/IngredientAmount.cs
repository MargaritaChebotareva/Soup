using System;
using UnityEngine;

namespace Assets.Scripts.ScriptableObjects.Ingredients
{
    [Serializable]
    public class IngredientAmount
    {
        [SerializeField] private string name;
        [Min(1)]
        [SerializeField] private int count;
        public string Name => name;
        public int Count => count;
    }
}