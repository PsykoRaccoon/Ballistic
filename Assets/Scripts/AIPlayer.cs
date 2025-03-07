using UnityEngine;

public class AIPlayer : MonoBehaviour
{
    public Transform ball;
    public float speed, limit, smoothTime;
    public Axis moveAxis;

    private float targetPos, velocity;

    public enum Axis { X, Z }

    void Update()
    {
        targetPos = moveAxis == Axis.X ? ball.position.x : ball.position.z;
        targetPos = Mathf.Clamp(targetPos, -limit, limit);

        if (moveAxis == Axis.X)
            transform.position = new Vector3(
                Mathf.SmoothDamp(transform.position.x, targetPos, ref velocity, smoothTime),
                transform.position.y,
                transform.position.z
            );
        else
            transform.position = new Vector3(
                transform.position.x,
                transform.position.y,
                Mathf.SmoothDamp(transform.position.z, targetPos, ref velocity, smoothTime)
            );
    }
}
