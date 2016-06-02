using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour
{
    public bool canScroll = false;
    private PlayerController PlayerController; //reff to PlayerController
    private RaycastingManager RaycastingManager; // reff to the RaycastingManager
    private MouseController MouseController; // reff to MouseController
    private GameObject myGo;
    private float xAxis = 0; // left and right movement  (1+ right, -1 left)
    private float zAxis = 0; // front and back movement (1+ forward, -1 back)
    float mouseXAxis = 0; // left or right movement of mouse (camera). Positive numb = right, Negative numb = left
    float mouseYAxis = 0; // up or down movement of mouse (camera). Positive numb = up, Negative numb = down.
    float mouseScrolling = 0;

    void Awake ()
    {
        PlayerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        RaycastingManager = GameObject.FindGameObjectWithTag("T_RaycastManager").GetComponent<RaycastingManager>();
    }
	
	void Update ()
    {
        //MOUSE INPUTS
        //using the variables mouseXaxis and Yaxis, get the input > Axis Settings called Mouse X and Y. They have the mouse controllers
        mouseXAxis = Input.GetAxis("Mouse X");
        mouseYAxis = Input.GetAxis("Mouse Y");
        mouseScrolling = Input.GetAxis("Mouse ScrollWheel");
       
        if (mouseXAxis != 0 || mouseYAxis != 0)
        {
            PlayerController.MouseLook(mouseXAxis, mouseYAxis);
        }

        if (canScroll == true)
        {
            if (mouseScrolling != 0)
            {
                MouseController.pushPullObject(mouseScrolling);
            }
        }

        // RAYCASTING + OBJECT DRAGGING
        if (Input.GetMouseButtonDown(0))
        {
            //MouseController.OnMouseDrag();
            RaycastingManager.CastRay();
            canScroll = true;
            print("canScroll = " + canScroll);
        }
        if (Input.GetMouseButtonUp(0))
        {
            canScroll = false;
            print("canScroll = " + canScroll);
        }
       
        // PLAYER MOVEMENT INPUTS
        //using the variables mouseXaxis and Yaxis, get the input > Axis Settings called Mouse X and Y. They have the mouse controllers
        xAxis = Input.GetAxisRaw("Horizontal");
        zAxis = Input.GetAxisRaw("Vertical");


        //only move if the value of horizontal axis(xAxis), vertical axis(zAxis) is not equal to 0
        if (xAxis != 0 || zAxis != 0)
        {
            // instruction same above
            PlayerController.PlayerMove(xAxis, zAxis);
        }


        //JUMPING
        if (Input.GetKey(KeyCode.Space))
        {
            PlayerController.PlayerJump();
        }
    }
}
