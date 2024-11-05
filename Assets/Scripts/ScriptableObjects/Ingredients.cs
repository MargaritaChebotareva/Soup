using Assets.Scripts.ScriptableObjects.Common;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.ScriptableObjects
{

    [CreateAssetMenu(menuName = "Scriptable Objects/Ingredients", fileName = "Ingredients", order = 2)]
    public class Ingredients : ScriptableObject
    {
        [SerializeField] private List<Ingredient> ingrediens = new();
        public string[] GetNames()
        {
            return ingrediens.Select(x => x.Name).ToArray();
        }
        public Core.Entities.IngredientType[] GetIngredientTypes()
        {
            return ingrediens.Select(x => new Core.Entities.IngredientType(x.Name, x.Price)).ToArray();
        }

        public Ingredient[] GetPrefabs()
        {
            return ingrediens.ToArray();
        }
    }
}