using UnityEngine;

namespace Assets.Scripts.ScriptableObjects
{
    [CreateAssetMenu(menuName = "Scriptable Objects/New Tag", fileName = "New Tag", order = 6)]
    public class Tag : ScriptableObject
    {
        [SerializeField] private string tag;
        public string GetTag()
        {
            return tag;
        }
    }
}