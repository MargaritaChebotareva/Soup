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
    }
}