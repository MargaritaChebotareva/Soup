using System;
using UnityEngine;

namespace Assets.Scripts.ScriptableObjects.Recipes
{
    [Serializable]
    public class EditorRecipePair
    {
        [SerializeField] private string ingredientName;
        [Min(1)]
        [SerializeField] private int count;
    }
}