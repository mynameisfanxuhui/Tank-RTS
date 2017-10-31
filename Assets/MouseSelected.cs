using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseSelected : MonoBehaviour {
    private Vector3 startPosition;
    private Vector3 endPosition;
    private GameObject go;
    void Start()
    {
        go = this.gameObject;
        //selectedGo = new List<GameObject> ();
        Debug.Log(go.transform.position);
    }
    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            MouseManager.selectedTank.Clear();
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
            Vector3 goPosition = Camera.main.WorldToScreenPoint(go.transform.position);
            //Debug.Log(goPosition+"gameObject position");
            if (selectionBox.Contains(goPosition))
            {
                Debug.Log("selected");
                MouseManager.selectedTank.Add(go);
            }

        }
    }
}
