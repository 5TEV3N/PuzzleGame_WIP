﻿using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour
{
    private PlayerController PlayerController;
    private float xAxis = 0; // left and right movement  (1+ right, -1 left)
    private float zAxis = 0; // front and back movement (1+ forward, -1 back)
    float mouseXAxis = 0; // left or right movement of mouse (camera). Positive numb = right, Negative numb = left
    float mouseYAxis = 0; // up or down movement of mouse (camera). Positive numb = up, Negative numb = down.

    void Awake ()
    {
        PlayerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
	}
	
	void Update ()
    {
        //MOUSE INPUTS
        //using the variables mouseXaxis and Yaxis, get the input > Axis Settings called Mouse X and Y. They have the mouse controllers
        mouseXAxis = Input.GetAxis("Mouse X");
        mouseYAxis = Input.GetAxis("Mouse Y");

        if (mouseXAxis != 0 || mouseYAxis != 0)
        {
            PlayerController.MouseLook(mouseXAxis, mouseYAxis);
        }

    }
}