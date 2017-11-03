using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTreasures : MonoBehaviour {
    public GameObject treasure;
    private int count=0;
    private Transform[] position;
    private bool[] isCreated;
    private void Start()
    {
        
        int children = transform.childCount;
        position = new Transform[children];
        isCreated = new bool[children];
        for (int i = 0; i < children; ++i)
        {
            
            position.SetValue(transform.GetChild(i),i);

        }
    }
    private void Update()
    {
         count++;
        if(count>=300)
        {
            Transform element = position[Random.Range(0, position.Length)];
            Instantiate(treasure, element.position, Quaternion.identity);
            Debug.Log("create");
            count = 0;
        }
    }
}
