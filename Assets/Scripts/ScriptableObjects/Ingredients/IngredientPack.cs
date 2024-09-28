using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.ScriptableObjects.Ingredients
{
    [CreateAssetMenu]
    public class IngredientPack : ScriptableObject
    {
        [SerializeField] private List<EditorIngredientType> ingredientTypes = new List<EditorIngredientType>();
        [SerializeField] private List<EditorIngredient> startPack = new List<EditorIngredient>();
        public string[] GetAllIngredients()
        {
            return ingredientTypes.Select(x => x.GetName()).ToArray();
        }
    }
}