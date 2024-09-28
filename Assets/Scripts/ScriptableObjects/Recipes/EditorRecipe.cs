using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.ScriptableObjects.Recipes
{
    [Serializable]
    public class EditorRecipe
    {
        [SerializeField] private string name;
        [SerializeField] private int price;
        [SerializeField] private List<EditorRecipePair> composition;
    }
}