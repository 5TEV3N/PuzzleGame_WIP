using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float playerSpeed;
    public float mouseSensitivity = 1;
    public Camera playerCamera;

    public Rigidbody rb;

    private Vector3 move;

    void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody>(); // reff to Rigidbody component
        move = new Vector3(rb.velocity.x,0f,rb.velocity.z);

    }

    public void MouseLook(float mouseXAxis, float mouseYAxis)
    {
        // rotate the player charecter on the y axis to look left or right. This is done so that you dont fuck up the camera up
        transform.Rotate(0, mouseXAxis * mouseSensitivity, 0);

        // rotate the camera on the x axis to look up and down.
        playerCamera.transform.Rotate(-mouseYAxis * mouseSensitivity, 0, 0);
    }

    public void PlayerMove(float xAxis, float zAxis)
    {
        if (xAxis != 0 )
        {
            if (xAxis > 0 ) //if moving right
            {
                rb.AddForce(transform.right * playerSpeed);
            }

            if (xAxis < 0 ) // if moving left
            {
                rb.AddForce(-transform.right * playerSpeed);
            }
        }

        else if (zAxis!=0)
        {
            if (zAxis > 0) // if moving forward
            {
                rb.AddForce(transform.forward * playerSpeed);
            }

            if (zAxis < 0) // if moving back
            {
                rb.AddForce(-transform.forward * playerSpeed);
            }
        }
    }
}
