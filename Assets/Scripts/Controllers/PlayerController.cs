using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float playerSpeed;
    public float mouseSensitivity = 1f;
    public float jumpHeight = 200f;

    public Camera playerCamera;
    public Rigidbody rb;

    private bool isGrounded;

    void Awake ()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void MouseLook(float mouseXAxis, float mouseYAxis)
    {
        // rotate the player charecter on the y axis to look left or right. This is done so that you dont fuck up the camera up
        transform.Rotate(0, mouseXAxis * mouseSensitivity, 0);

        // rotate the camera on the x axis to look up and down.
        playerCamera.transform.Rotate(-mouseYAxis * mouseSensitivity, 0, 0);
        
        if (-mouseYAxis >= 180)
        {
            print("aswdf");
        }
       
    }

    public void PlayerMove(float xAxis, float zAxis)
    {
        //if you're not moving Left or Right
        if (xAxis != 0)
        {
            if (xAxis > 0)
            {
                //positive x = Right
                rb.AddForce(transform.right * playerSpeed);
            }

            if (xAxis < 0)
            {
                //negative x = Left
                rb.AddForce(-transform.right * playerSpeed);
            }

        }

        //if you're not moving Forward or Back
        if (zAxis != 0)
        {
            if (zAxis > 0)
            {
                //positive z = Forward
                rb.AddForce(transform.forward * playerSpeed);
            }

            if (zAxis < 0)
            {
                //negative z = Back
                rb.AddForce(-transform.forward * playerSpeed);
            }
        }
    }

    void OnCollisionExit(Collision other)
    {
        print(isGrounded);
        isGrounded = false;
    }

    void OnCollisionEnter(Collision other)
    {
        print(isGrounded);
        isGrounded = true;
    }

    public void PlayerJump()
    {
        if (isGrounded == true)
        {
            print("jumping");
            rb.AddForce(0f, jumpHeight, 0f);
        }
    }

}
