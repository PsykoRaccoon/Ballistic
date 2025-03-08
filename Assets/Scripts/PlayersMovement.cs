using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float limitX;
    public float limitZ;
    public float smoothTime;

    public int playerIndex; 
    public enum Axis { X, Z } 
    public Axis movementAxis; 

    private float target, velocity;

    void Update()
    {
        string horizontalInput = "Horizontal";
        switch (playerIndex)
        {
            case 2:
                horizontalInput = "Horizontal2";
                break;
            case 3:
                horizontalInput = "Horizontal3";
                break;
            case 4:
                horizontalInput = "Horizontal4";
                break;
        }

        switch (movementAxis)
        {
            case Axis.X:
                target += Input.GetAxis(horizontalInput) * speed * Time.deltaTime;
                target = Mathf.Clamp(target, -limitX, limitX);
                transform.position = new Vector3(Mathf.SmoothDamp(transform.position.x, target, ref velocity, smoothTime), transform.position.y, transform.position.z);
                break;

            case Axis.Z:
                target += Input.GetAxis(horizontalInput) * speed * Time.deltaTime;
                target = Mathf.Clamp(target, -limitZ, limitZ);
                transform.position = new Vector3(transform.position.x, transform.position.y, Mathf.SmoothDamp(transform.position.z, target, ref velocity, smoothTime));
                break;
        }
    }
}
