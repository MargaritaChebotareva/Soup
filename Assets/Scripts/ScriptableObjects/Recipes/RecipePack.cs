using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.ScriptableObjects.Recipes
{
    [CreateAssetMenu]
    public class RecipePack : ScriptableObject
    {
        [SerializeField] private List<EditorRecipe> recipePack = new List<EditorRecipe>();
    }
}