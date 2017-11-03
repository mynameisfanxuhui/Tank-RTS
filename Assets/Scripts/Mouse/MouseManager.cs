using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseManager : MonoBehaviour {
    public float pokeForce;
    public static List<GameObject> selectedTank;
  //  
    // Update is called once per frame
    private void Start()
    {
       // m_CanvasGameObject = new GameObject();
        selectedTank = new List<GameObject>();
    }
    void Update () {


        foreach (GameObject selected in selectedTank)
        {
            GameObject m_CanvasGameObject = selected.GetComponentInChildren<Canvas>(true).gameObject;
            m_CanvasGameObject.SetActive(true);
        }
		if (Input.GetMouseButtonDown (1)) 
		{
            FactoryManager.isSelected = false;
            foreach (GameObject selected in selectedTank) 
			{
                
                //Vector3 temp = Input.mousePosition;
                //temp.x = Input.mousePosition.x;
                //temp.y = Camera.main.pixelHeight - Input.mousePosition.y;

                //Vector3 targetPos = Camera.main.ScreenToWorldPoint(new Vector3(temp.x, temp.y, Camera.main.nearClipPlane));
                //Debug.Log("targetpos="+targetPos);
                Rigidbody rig = selected.GetComponent<Rigidbody> ();
                //Vector3 dir = cursorOnTransform;
				//dir.y = 0;
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                Debug.DrawRay(ray.origin, ray.direction * 100, Color.yellow);
                Debug.Log(Input.mousePosition);
                Debug.Log(ray.direction);

                if (Physics.Raycast(ray, out hit))
                if (hit.collider != null)
                {
                    Vector3 forcePos = hit.point - transform.position;
                    rig.velocity = forcePos;
                    Debug.Log("velocity="+rig.velocity);

                }
                        
                //rig.AddForce(dir);
			}
		}
    }
    //private static Vector3 cursorWorldPosOnNCP
    //{
    //    get
    //    {
    //        return Camera.main.ScreenToWorldPoint(
    //            new Vector3(Input.mousePosition.x,
    //            Input.mousePosition.y,
    //            Camera.main.nearClipPlane));
    //    }
    //}

    //private static Vector3 cameraToCursor
    //{
    //    get
    //    {
    //        return cursorWorldPosOnNCP - Camera.main.transform.position;
    //    }
    //}

    //private Vector3 cursorOnTransform
    //{
    //    get
    //    {
    //        Debug.Log("transform="+transform.position);
    //        Vector3 camToTrans = transform.position - Camera.main.transform.position;
    //        return Camera.main.transform.position +
    //            cameraToCursor *
    //            (Vector3.Dot(Camera.main.transform.forward, camToTrans) / Vector3.Dot(Camera.main.transform.forward, cameraToCursor));
    //    }
    //}
}
