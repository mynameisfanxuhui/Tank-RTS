using System;
using UnityEngine;
using System.Collections.Generic;
[Serializable]
public class TankManager
{
    public Color m_PlayerColor;            
    public Transform m_SpawnPoint;         
    [HideInInspector] public int m_PlayerNumber;             
    [HideInInspector] public string m_ColoredPlayerText;
    [HideInInspector] public GameObject m_Instance;          
    [HideInInspector] public int m_Wins;                     


    private TankMovement m_Movement;       
    private TankShooting m_Shooting;
    private MouseSelected m_Mouse;
    private GameObject m_CanvasGameObject;

    public void EnableCanvas()
    {
        m_CanvasGameObject.SetActive(true);
    }
    public void DisableCanvas()
    {
        m_CanvasGameObject.SetActive(false);
    }
    public void Setup()
    {

        m_Movement = m_Instance.GetComponent<TankMovement>();
        m_Shooting = m_Instance.GetComponent<TankShooting>();
        m_Mouse = m_Instance.GetComponent<MouseSelected>();
        m_CanvasGameObject = m_Instance.GetComponentInChildren<Canvas>().gameObject;
        m_CanvasGameObject.SetActive(false);
        m_Movement.m_PlayerNumber = m_PlayerNumber;
        m_Shooting.m_PlayerNumber = m_PlayerNumber;

        m_ColoredPlayerText = "<color=#" + ColorUtility.ToHtmlStringRGB(m_PlayerColor) + ">PLAYER " + m_PlayerNumber + "</color>";

        MeshRenderer[] renderers = m_Instance.GetComponentsInChildren<MeshRenderer>();

        for (int i = 0; i < renderers.Length; i++)
        {
            renderers[i].material.color = m_PlayerColor;
        }
    }


    public void DisableControl()
    {
        m_Movement.enabled = false;
        m_Shooting.enabled = false;
        m_Mouse.enabled = false;

    }


    public void EnableControl()
    {
        m_Movement.enabled = true;
        m_Shooting.enabled = true;
        m_Mouse.enabled = true;

    }


    public void Reset()
    {
        m_Instance.transform.position = m_SpawnPoint.position;
        m_Instance.transform.rotation = m_SpawnPoint.rotation;

        m_Instance.SetActive(false);
        m_Instance.SetActive(true);
    }
}
