using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed;
    public float randomness;
    private Rigidbody rb;

    public string LastCollisionTag { get; private set; }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = GetRandomDirection() * speed;
        rb.useGravity = false;
    }

    void FixedUpdate()
    {
        rb.velocity = rb.velocity.normalized * speed;
    }

    void OnCollisionEnter(Collision collision)
    {
        Vector3 normal = collision.contacts[0].normal;
        Vector3 newDirection = Vector3.Reflect(rb.velocity, normal);
        LastCollisionTag = collision.gameObject.tag;

        newDirection.x += Random.Range(-randomness, randomness);
        newDirection.z += Random.Range(-randomness, randomness);
        newDirection = newDirection.normalized;

        rb.velocity = newDirection * speed;
    }

    Vector3 GetRandomDirection()
    {
        Vector2 randomDir = Random.insideUnitCircle.normalized;
        return new Vector3(randomDir.x, 0, randomDir.y);
    }
}
