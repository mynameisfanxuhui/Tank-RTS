using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class Treasures : MonoBehaviour {
    private Text moneyNum;
    private void Start()
    {
        moneyNum = GameObject.Find("MoneyNumber").GetComponent<Text>();
    }
    private void OnTriggerEnter(Collider other)
    {
        
        int num= Convert.ToInt32(moneyNum.text);
        moneyNum.text = Convert.ToString(num += 10);
        Destroy(gameObject);
    }

}
