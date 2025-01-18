using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.ScriptableObjects
{
    [CreateAssetMenu(menuName = "Scriptable Objects/New Tag Chain", fileName = "New Tag Chain", order = 7)]
    [System.Serializable]
    public class TagChain : ScriptableObject
    {
        [SerializeField]
        public List<Tag> tags;

        public bool IsEmpty()
        {
            return tags == null || tags.Count == 0;
        }
    }
}