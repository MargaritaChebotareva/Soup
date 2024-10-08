using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.ScriptableObjects.Ingredients
{
    [CreateAssetMenu(fileName = "IngredientTypeSet", order = 1)]
    public class IngredientTypeSet : ScriptableObject
    {
        [SerializeField] private List<IngredientType> ingredientTypes = new();
        public string[] GetNames()
        {
            return ingredientTypes.Select(x => x.Name).ToArray();
        }
        public Core.Entities.IngredientType[] GetTypes()
        {
            return ingredientTypes.Select(x => new Core.Entities.IngredientType(x.Name, x.Price)).ToArray();
        }
    }
}