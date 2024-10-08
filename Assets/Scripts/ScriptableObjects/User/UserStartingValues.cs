using UnityEngine;

namespace Assets.Scripts.ScriptableObjects.User
{
    [CreateAssetMenu(fileName = "UserStartingValues", order = 3)]
    public class UserStartingValues : ScriptableObject
    {
        [Min(0)]
        [SerializeField] private int money;

        public int Money => money;

    }
}