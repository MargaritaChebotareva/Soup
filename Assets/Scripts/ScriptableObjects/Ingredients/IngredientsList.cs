using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.ScriptableObjects.Ingredients
{
    [Serializable]
    public class IngredientsList
    {
        [SerializeField] private IngredientTypeSet types;
        [SerializeField] private List<IngredientAmount> items = new ();

        public void SetTypes(IngredientTypeSet types)
        {
            this.types = types;
        }

        public Core.Entities.Ingredient[] GetIngredients()
        {
            List<Core.Entities.Ingredient> list = new List<Core.Entities.Ingredient>(items.Count);
            foreach (var item in items)
            {
                for (int i = 0; i < item.Count; i++)
                {
                    list.Add(new Core.Entities.Ingredient(0, item.Name));
                }
            }
            return list.ToArray();
        }
    }
}