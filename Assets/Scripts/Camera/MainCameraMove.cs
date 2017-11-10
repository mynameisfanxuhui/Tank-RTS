using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraMove : MonoBehaviour {

    public int Boundary = 50; // distance from edge scrolling starts
    public float speed = 5;
    private int theScreenWidth;
    private int theScreenHeight;
    void Start()
    {
        theScreenWidth = Screen.width;
        theScreenHeight = Screen.height;
    }
    void Update()
    {
        if (Input.mousePosition.x > theScreenWidth - Boundary)
        {
            Vector3 temp = transform.position;
            temp.x+=speed * Time.deltaTime;
            transform.position = temp;
        }
        if (Input.mousePosition.x < 0 + Boundary)
        {
            Vector3 temp = transform.position;
            temp.x -= speed * Time.deltaTime;
            transform.position = temp;
        }
        if (Input.mousePosition.y > theScreenHeight - Boundary)
        {
            Vector3 temp = transform.position;
            temp.z += speed * Time.deltaTime;
            transform.position = temp;
        }
        if (Input.mousePosition.y < 0 + Boundary)
        {
            Vector3 temp = transform.position;
            temp.z -= speed * Time.deltaTime;
            transform.position = temp;
        }
    }
    //void OnGUI()
    //{
    //    GUI.Box(new Rect((Screen.width / 2) - 140, 5, 280, 25), "Mouse Position = " + Input.mousePosition);
    //    GUI.Box(new Rect((Screen.width / 2) - 70, Screen.height - 30, 140, 25), "Mouse X = " + Input.mousePosition.x);
    //    GUI.Box(new Rect(5, (Screen.height / 2) - 12, 140, 25), "Mouse Y = " + Input.mousePosition.y);

    //}
}
