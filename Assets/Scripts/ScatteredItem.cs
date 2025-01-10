using UnityEngine;

public class ScatteredItem : MonoBehaviour
{
    [SerializeField] private MeshCollider meshCollider;
    [SerializeField] private Rigidbody rb;
    [field: SerializeField] public int Type { get; private set; }

    public Rigidbody GetRigidbody()
    {
        return rb;
    }

    public void Launch(Vector3 startPoint)
    {
        rb.isKinematic = false;
        gameObject.SetActive(true);
        rb.MovePosition(startPoint);
        rb.MoveRotation(Random.rotationUniform);
    }
}
