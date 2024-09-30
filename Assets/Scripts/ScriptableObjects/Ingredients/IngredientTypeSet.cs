using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.ScriptableObjects.Ingredients
{
    [CreateAssetMenu(fileName = "IngredientTypeSet", order = 1)]
    public class IngredientTypeSet : ScriptableObject
    {
        [SerializeField] private List<IngredientType> ingredientTypes = new();
        public string[] GetAllIngredients()
        {
            return ingredientTypes.Select(x => x.GetName()).ToArray();
        }
    }
}