using System;
using UnityEngine;

namespace Assets.Scripts.ScriptableObjects.Common
{
    [Serializable]
    public class Ingredient
    {
        [SerializeField] private string name;
        [SerializeField] private int pricePerUnit;
        [SerializeField] private Prefabs.Ingredient prefab;

        public string Name => name;
        public int Price => pricePerUnit;

        public Prefabs.Ingredient Prefab => prefab;
    }
}