using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseManager : MonoBehaviour {
    //public float pokeForce;
    public float speed;
   // public float rotateSpeed;
    public float accuracy;
    public static List<GameObject> selectedTank;
    public Camera mainCam;
    private Vector3 pointPosition;
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
            RaycastHit hit;
            Ray ray = mainCam.ScreenPointToRay(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z));
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider != null)
                {
                    foreach (GameObject tank in selectedTank)
                    {
                        Transform trans = tank.GetComponent<Transform>();
                        Vector3 forcePos = hit.point - tank.transform.position;
                        forcePos = new Vector3(forcePos.x, 0, forcePos.z);
                        //float step = rotateSpeed * Time.deltaTime;
                        //Vector3 newDir = Vector3.RotateTowards(trans.forward, forcePos, step, 0.0F);
                        //trans.rotation = Quaternion.LookRotation(newDir);
                        trans.LookAt(hit.point);
                        forcePos = forcePos.normalized * speed;
                        Rigidbody rigid = tank.GetComponent<Rigidbody>();
                        rigid.velocity = forcePos;
                    }

                    //transform.position = Vector3.MoveTowards(transform.position, hit.point, 5);
                    //rig.AddForceAtPosition(forcePos,hit.point);
                    pointPosition = hit.point;
                    //Debug.Log("velocity=" + rig.velocity);
                }
            }
                
        }
        foreach (GameObject tank in selectedTank)
        {
            if (Mathf.Abs(tank.transform.position.x - pointPosition.x) < accuracy && Mathf.Abs(tank.transform.position.z - pointPosition.z) < accuracy)
            {
                Rigidbody rig = tank.GetComponent<Rigidbody>();
                rig.velocity = Vector3.zero;
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
