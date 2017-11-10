using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseSelect : MonoBehaviour
{
    private Vector3 startPosition;
    private Vector3 endPosition;
    private Vector3 pointPosition;

    //private GameObject cube;
    public static bool isSelected;
    public float accuracy;
    public List<GameObject> selectedCube;
    // Use this for initialization
    void Start()
    {
        //cube = gameObject;
        isSelected = false;

    }
    IEnumerator VelocityChange(Vector3 forcePos, Vector3 pointPos,Rigidbody rig)
    {
        rig.velocity = forcePos;
        yield return true;
    }
    private void OnTriggerEnter(Collider other)
    {
        foreach (GameObject cube in selectedCube)
        {
            Debug.Log("trigger enter");
                Rigidbody rig = cube.GetComponent<Rigidbody>();
                rig.velocity = Vector3.zero;
            
        }
    }
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            isSelected = false;
            startPosition = Input.mousePosition;
            //Debug.Log (startPosition);

        }
        if (Input.GetMouseButtonUp(0))
        {
            endPosition = Input.mousePosition;
            //Debug.Log (endPosition+"end");

            Rect selectionBox = new Rect(Mathf.Min(startPosition.x, endPosition.x),
                Mathf.Min(startPosition.y, endPosition.y),
                Mathf.Abs(startPosition.x - endPosition.x),
                Mathf.Abs(startPosition.y - endPosition.y));
            Vector3 goPosition = Camera.main.WorldToScreenPoint(transform.position);
            //Debug.Log(goPosition+"gameObject position");
            if (selectionBox.Contains(goPosition))
            {
                Debug.Log("selected");
                isSelected = true;
            }

        }
        if (Input.GetMouseButtonDown(1))
        {

            if(isSelected)
            {
                //Rigidbody rig = cube.GetComponent<Rigidbody>();
                //Vector3 dir = cursorOnTransform;
                //dir.y = 0;
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z));
                //Debug.DrawRay(ray.origin, ray.direction * 100, Color.yellow);
                //Debug.Log("mousePosition=" + Input.mousePosition);
                //Debug.Log("direction=" + ray.direction);

                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider != null)
                    {
                        foreach (GameObject cube in selectedCube)
                        {
                           Vector3 forcePos = hit.point - cube.transform.position;
                           forcePos = new Vector3(forcePos.x, 0, forcePos.z);
                           forcePos = forcePos.normalized*3;

                            Rigidbody rig = cube.GetComponent<Rigidbody>();
                            rig.velocity = forcePos;
                        }
                     
                        //transform.position = Vector3.MoveTowards(transform.position, hit.point, 5);
                        //rig.AddForceAtPosition(forcePos,hit.point);
                        pointPosition = hit.point;
                        //Debug.Log("velocity=" + rig.velocity);
                    }
                }
            }
        }
        foreach(GameObject cube in selectedCube)
        {
            if (Mathf.Abs(cube.transform.position.x - pointPosition.x) < accuracy && Mathf.Abs(cube.transform.position.z - pointPosition.z) < accuracy)
            {
                Rigidbody rig = cube.GetComponent<Rigidbody>();
                rig.velocity = Vector3.zero;
            }
        }


    }
}
