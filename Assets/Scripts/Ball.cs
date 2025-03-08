using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour
{
    public float speed;
    public float randomness;
    public float resetTime;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        RestartMovement();
    }

    void FixedUpdate()
    {
        rb.velocity = rb.velocity.normalized * speed;
    }

    void OnCollisionEnter(Collision collision)
    {
        Vector3 normal = collision.contacts[0].normal;
        Vector3 newDirection = Vector3.Reflect(rb.velocity, normal);

        newDirection.x += Random.Range(-randomness, randomness);
        newDirection.z += Random.Range(-randomness, randomness);
        newDirection = newDirection.normalized;

        rb.velocity = newDirection * speed;
    }

    public void ResetBall()
    {
        StartCoroutine(ResetBallRoutine());
    }

    private IEnumerator ResetBallRoutine()
    {
        rb.velocity = Vector3.zero; 
        transform.position = Vector3.zero; 

        yield return new WaitForSeconds(resetTime); 

        yield return null; 
        RestartMovement();
    }

    private void RestartMovement()
    {
        Vector3 newDirection = GetRandomDirection();
        rb.velocity = newDirection * speed;
    }

    Vector3 GetRandomDirection()
    {
        Vector2 randomDir = Random.insideUnitCircle.normalized;
        return new Vector3(randomDir.x, 0, randomDir.y);
    }
}
