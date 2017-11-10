using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryManager : MonoBehaviour {
    private Vector3 startPosition;
    private Vector3 endPosition;
    private GameObject m_CanvasGameObject;
    private GameObject factory;
    public static bool isSelected;
	// Use this for initialization
	void Start () {
        m_CanvasGameObject = GetComponentInChildren<Canvas>().gameObject;
        m_CanvasGameObject.SetActive(false);
        factory = this.gameObject;
        isSelected = false;

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
            Vector3 goPosition = Camera.main.WorldToScreenPoint(factory.transform.position);
            //Debug.Log(goPosition+"gameObject position");
            if (selectionBox.Contains(goPosition))
            {
                Debug.Log("selected");
                isSelected = true;
            }

        }
        if (isSelected)
            m_CanvasGameObject.SetActive(true);
    }
}
