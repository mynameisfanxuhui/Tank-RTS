using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseManager : MonoBehaviour {
	private Vector3 startPosition;
	private Vector3 endPosition;
	public GameObject go;
	private List<GameObject> selectedGo;
	void Start(){
		selectedGo = new List<GameObject> ();
        Debug.Log(go.transform.position);
	}
	// Update is called once per frame
	void Update () {
		
		if (Input.GetMouseButtonDown (0)) 
		{
			startPosition = Input.mousePosition;
			//Debug.Log (startPosition);

		}
		if (Input.GetMouseButtonUp (0)) 
		{
			endPosition = Input.mousePosition;
			//Debug.Log (endPosition+"end");
			Rect selectionBox = new Rect(Mathf.Min(startPosition.x, endPosition.x), 
				Mathf.Min(startPosition.y, endPosition.y),
				Mathf.Abs(startPosition.x - endPosition.x),
				Mathf.Abs(startPosition.y - endPosition.y));
			Vector3 goPosition = Camera.main.WorldToScreenPoint (go.transform.position);
			//Debug.Log(goPosition+"gameObject position");
			if (selectionBox.Contains (goPosition))
			{
				Debug.Log("selected");
				selectedGo.Add (go);
			}
				
		}
		if (Input.GetMouseButtonDown (1)) 
		{
            
			foreach (GameObject selected in selectedGo) 
			{
                
                Vector3 temp = Input.mousePosition;
                temp.x = Input.mousePosition.x;
                temp.y = Camera.main.pixelHeight - Input.mousePosition.y;

                Vector3 targetPos = Camera.main.ScreenToWorldPoint(new Vector3(temp.x, temp.y, Camera.main.nearClipPlane));
                Debug.Log("targetpos="+targetPos);
                Rigidbody rig = selected.GetComponent<Rigidbody> ();
                Vector3 dir = (targetPos - selected.transform.position).normalized;
				//dir.y = 0;
				Debug.Log ("direction =" + dir);
                rig.velocity=dir * 10f;
			}
		}


	}
}
