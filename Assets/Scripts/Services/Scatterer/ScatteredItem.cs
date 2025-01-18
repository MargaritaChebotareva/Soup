using Assets.Scripts.ScriptableObjects;
using UnityEngine;

namespace Assets.Scripts.Services.Scatterer
{
    [RequireComponent(typeof(Rigidbody))]
    public class ScatteredItem : MonoBehaviour
    {
        private Rigidbody rb;
        [field: SerializeField] public TagChain TagChain { get; private set; }

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
        }
        public bool IsSleeping()
        {
            return rb.IsSleeping();
        }

        public bool IsActiveSelf()
        {
            return gameObject.activeSelf;
        }

        public void Launch(Vector3 startPoint)
        {
            rb.isKinematic = false;
            gameObject.SetActive(true);
            rb.MovePosition(startPoint);
            rb.MoveRotation(Random.rotationUniform);
        }
    }
}