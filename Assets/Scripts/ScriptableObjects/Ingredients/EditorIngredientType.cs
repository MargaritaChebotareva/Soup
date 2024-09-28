using System;
using UnityEngine;

namespace Assets.Scripts.ScriptableObjects.Ingredients
{
    [Serializable]
    public class EditorIngredientType
    {
        [SerializeField] private string name;
        [SerializeField] private int pricePerUnit;

        public string GetName()
        {
            return name;
        }
    }
}