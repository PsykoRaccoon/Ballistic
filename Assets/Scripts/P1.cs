using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1 : MonoBehaviour
{
    public float speed, limitX, smoothTime;
    private float targetX, velocity;

    void Update()
    {
        targetX += Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        targetX = Mathf.Clamp(targetX, -limitX, limitX);
        transform.position = new Vector3(Mathf.SmoothDamp(transform.position.x, targetX, ref velocity, smoothTime), transform.position.y, transform.position.z);
    }
}
