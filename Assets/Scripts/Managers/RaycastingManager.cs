using UnityEngine;
using System.Collections;

public class RaycastingManager : MonoBehaviour
{
    Ray myRay; //Declaring a ray variable, register an actual ray
    RaycastHit myHit; //Declaring a hit variable, registers a ray hit (gets information on hit)
    Vector3 startMarker; //Declaring a container for the start position for the ray	

    void Start()
    {
        //Locks cursor and makes it invisible
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        //Assign in the real time start position for the ray
        startMarker = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //startMarker = The camera . main (main is the first enabled camera in the hierachy) . Screen into the world ( cursor is displayed on the same plane as the camera) Input.mousePosition

        //A ray to extract a direction from
        myRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        // The ray is equal to the Camera . main . returns a ray going from camera to a point in the screen

        //Draw ray to help debug
        Debug.DrawRay(startMarker, myRay.direction * 1000, Color.magenta);
        //Project a constant ray by getting the directions = Vector 3 Start( so where the ray starts from) , Vector 3 Direction (myRay.direction (direction of they ray) *1000 (multiplies how long the ray is), and Colour

        //Unlocks the cursor *DEV*
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    public GameObject CastRay() // what the ray does (interaction)
    {
        //Actually Cast the ray on Command --> output collider to myhit ("out" keyword). myhit=  has information from myray and puts it into myHit
        Physics.Raycast(myRay, out myHit, 1000f);
        // Casts a ray

        //Print collider hit, filter null errors
        if (myHit.collider != null) //if the ray is hits a collider and does not equal to null:
        {
            print(myHit.collider.gameObject);
            return myHit.collider.gameObject; // gets the actual game object within the scene, scripts and all
        }

        else
        {
            return null; //returns nothing
        }

    }
}
