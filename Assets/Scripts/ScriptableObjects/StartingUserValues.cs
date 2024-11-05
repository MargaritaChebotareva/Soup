using UnityEngine;

namespace Assets.Scripts.ScriptableObjects
{
    [CreateAssetMenu(menuName = "Scriptable Objects/StartingUserValues", fileName = "StartingUserValues", order = 1)]
    public class StartingUserValues : ScriptableObject
    {
        [Min(0)]
        [SerializeField] private int money;

        public int Money => money;

    }
}