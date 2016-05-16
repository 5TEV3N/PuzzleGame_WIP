using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float mouseSensitivity = 1;
    public Camera playerCamera;

    public void MouseLook(float mouseXAxis, float mouseYAxis)
    {
        // rotate the player charecter on the y axis to look left or right. This is done so that you dont fuck up the camera up
        transform.Rotate(0, mouseXAxis * mouseSensitivity, 0);

        // rotate the camera on the x axis to look up and down.
        playerCamera.transform.Rotate(-mouseYAxis * mouseSensitivity, 0, 0);
    }
}
