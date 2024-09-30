using UnityEngine;

namespace Assets.Scripts.ScriptableObjects.Ingredients
{
    [CreateAssetMenu(fileName = "StartingIngredients", order = 3)]
    public class StartingIngredients : ScriptableObject
    {
        [SerializeField] private IngredientTypeSet types;
        [SerializeField] private IngredientsList startingItems;

        public void OnValidate()
        {
            if (types != null) { startingItems.SetTypes(types); }
        }
    }
}