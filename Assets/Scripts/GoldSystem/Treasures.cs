using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class Treasures : MonoBehaviour {
    private Text moneyNum;
    public GameObject m_Shell;
    private void Start()
    {
        moneyNum = GameObject.Find("MoneyNumber").GetComponent<Text>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Players"))
        {
            getResults();
        }
        Destroy(gameObject);
    }
    private void getResults()
    {
        float random = UnityEngine.Random.Range(0, 100f);
        if (random < 50)
            getMoney();
        else if (random >= 50 && random < 80)
            getDamage();
        else
            getNothing();
    }
    private void getMoney()
    {
        int num = Convert.ToInt32(moneyNum.text);
        moneyNum.text = Convert.ToString(num += 10);
    }
    private void getDamage()
    {
        Instantiate(m_Shell, transform.position, transform.rotation);
    }
    private void getNothing()
    {
        
    }

}
