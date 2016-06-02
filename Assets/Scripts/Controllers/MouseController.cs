using UnityEngine;
using System.Collections;

public class MouseController : MonoBehaviour
{
    public float distance = 4; // How far you can can drag an object 
    public bool asdf;

    public void OnMouseDrag()
    {
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance); //Make a new Vector 3 which takes the position of your mouse's xy co ordinance
        Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition); //Make a Vector 3 value that takes the mouse position relative to your screen
        transform.position = objPosition; // transform the object to objPosition ;
    }

    public void pushPullObject(float mouseScrolling)
    {
        if (mouseScrolling > 0) //Scroll up
        {
            print("asdf");
            distance++;
        }

        if (mouseScrolling < 0) //Scroll down
        {
            distance--;
        }
    }
}

