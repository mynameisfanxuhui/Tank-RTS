using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class BuildTank : MonoBehaviour {
    private Button buildTank;
    private Text moneyNum;
    public Text errorMessage;
    private Transform tankBorn;
    public GameObject my_Tank;
    public ParticleSystem smoke;
    void Start()
    {
        tankBorn = GameObject.Find("industrial_factory").transform;
        errorMessage.enabled = false;
        moneyNum = GameObject.Find("MoneyNumber").GetComponent<Text>();
        buildTank = GetComponent<Button>();
        buildTank.onClick.AddListener(BuildOnClick);
    }

    void BuildOnClick()
    {
        Debug.Log("Button Clicked");
        int num = Convert.ToInt32(moneyNum.text);
        if(num>=20)
        {
            CreateTank();
            moneyNum.text = Convert.ToString(num -= 20);
        }
        else
        {
            Debug.Log("Money Not Enough");
            StartCoroutine(MoneyNotEnough());
        }
    }
    void CreateTank()
    {
        Instantiate(my_Tank,tankBorn.position+new Vector3(15f,0,0),Quaternion.identity);
        smoke.Play();
    }
    IEnumerator MoneyNotEnough()
    {
        errorMessage.enabled = true;
        yield return new WaitForSeconds(2f);
        errorMessage.enabled = false;
    }
}
