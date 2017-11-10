using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MouseSelected : MonoBehaviour {
    public Texture greenHat;
    private Vector3 startPosition;
    private Vector3 endPosition;
    private GameObject go;
    private Rect selectionBox;
    private bool isMouseDown;
    public Camera mainCam;
    private Rect guiBox;
    void Start()
    {
        
        mainCam = GameObject.Find("Main Camera").GetComponent<Camera>();
        isMouseDown = false;
        go = this.gameObject;
        //selectedGo = new List<GameObject> ();
        Debug.Log(go.transform.position);
    }
    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.layer == 9)
        {
            Rigidbody rig = GetComponent<Rigidbody>();
            rig.velocity = Vector3.zero;
            Debug.Log("layer is" + collision.gameObject.layer);
        }
            //Debug.Log("Tank hit");
    }
    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            isMouseDown = true;
            MouseManager.selectedTank.Clear();
            startPosition = Input.mousePosition;
            //Debug.Log (startPosition);

        }
        if(Input.GetMouseButton(0))
        {
            endPosition = Input.mousePosition;
            //Debug.Log (endPosition+"end");
            selectionBox = new Rect(Mathf.Min(startPosition.x, endPosition.x),
            Mathf.Min(startPosition.y, endPosition.y),
            Mathf.Abs(startPosition.x - endPosition.x),
            Mathf.Abs(startPosition.y - endPosition.y));
            guiBox = new Rect(Mathf.Min(startPosition.x, endPosition.x),
                              Screen.height-Mathf.Max(startPosition.y, endPosition.y),
            Mathf.Abs(startPosition.x - endPosition.x),
            Mathf.Abs(startPosition.y - endPosition.y));
        }
        if (Input.GetMouseButtonUp(0))
        {
            isMouseDown = false;

            
            Vector3 goPosition = mainCam.WorldToScreenPoint(go.transform.position);
            //Debug.Log(goPosition+"gameObject position");
            if (selectionBox.Contains(goPosition))
            {
                Debug.Log("selected");
                MouseManager.selectedTank.Add(go);
            }

        }
    }
    private void OnGUI()
    {
        if(isMouseDown)
        {
            
           // Debug.Log("x="+guiBox.x+"y="+guiBox.y);
            GUI.DrawTexture(guiBox,greenHat);
        }
           
    }
}
