using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.ScriptableObjects.Ingredients
{
    [Serializable]
    public class IngredientsList
    {
        [SerializeField] private IngredientTypeSet types;
        [SerializeField] private List<IngredientAmount> items = new List<IngredientAmount>();

        public void SetTypes(IngredientTypeSet types)
        {
            this.types = types;
        }
    }
}