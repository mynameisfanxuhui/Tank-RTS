using UnityEngine;
using UnityEngine.UI;

public class TankShooting : MonoBehaviour
{
    public int m_PlayerNumber = 1;       
    public Rigidbody m_Shell;            
    public Transform m_FireTransform;    
    public Slider m_AimSlider;           
    public AudioSource m_ShootingAudio;  
    public AudioClip m_ChargingClip;     
    public AudioClip m_FireClip;         
    public float m_MinLaunchForce = 15f; 
    public float m_MaxLaunchForce = 30f; 
    public float m_MaxChargeTime = 0.75f;

   
    private string m_FireButton;
    private bool isFireBuff;
    private string m_FireBuffButton;
    private float m_CurrentLaunchForce;  
    private float m_ChargeSpeed;         
    private bool m_Fired;                


    private void OnEnable()
    {
        m_CurrentLaunchForce = m_MinLaunchForce;
        m_AimSlider.value = m_MinLaunchForce;
    }


    private void Start()
    {
        m_FireButton = "Fire" + m_PlayerNumber;
        m_FireBuffButton = "FireBuff" + m_PlayerNumber;
        Debug.Log(m_FireBuffButton);
        m_ChargeSpeed = (m_MaxLaunchForce - m_MinLaunchForce) / m_MaxChargeTime;
        isFireBuff = false;
    }
  

    private void Update()
    {
        // Track the current state of the fire button and make decisions based on the current launch force.
        m_AimSlider.value = m_MinLaunchForce;
        if (m_CurrentLaunchForce >= m_MaxLaunchForce && !m_Fired)
        {
            m_CurrentLaunchForce = m_MaxLaunchForce;
            Fire();
        }
        else if (Input.GetButtonDown(m_FireButton))
        {
            m_Fired = false;
            //isFireBuff = false;
           // Debug.Log("start fire");
           // Debug.Log(m_Fired);
            m_CurrentLaunchForce = m_MinLaunchForce;
            m_ShootingAudio.clip = m_ChargingClip;
            m_ShootingAudio.Play();
        }
        else if (Input.GetButton(m_FireButton) && !m_Fired)
        {
          //  Debug.Log("firing");
            m_CurrentLaunchForce += m_ChargeSpeed * Time.deltaTime;
            m_AimSlider.value = m_CurrentLaunchForce;
        }
        else if ( Input.GetButtonDown(m_FireBuffButton))
        {
            isFireBuff = true;
            TankHealth tankHealth = GetComponent<TankHealth>();
            tankHealth.IsInvincible = true;
            //tankHealth.CurrentHealth = 100f;
            Debug.Log(isFireBuff);
        }
        else if (Input.GetButtonUp(m_FireButton)&&!m_Fired)
        {
            Fire();
        }
        
    }


    private void Fire()
    {
        // Instantiate and launch the shell.
        m_Fired = true;
        Rigidbody shellInstance = Instantiate(m_Shell, m_FireTransform.transform.position, m_FireTransform.transform.rotation) as Rigidbody;
        
        if (isFireBuff)
        {
            Debug.Log("FiringggggBuff");
            ShellExplosion shellExplosion = shellInstance.GetComponent<ShellExplosion>();
            shellExplosion.m_MaxDamage = 1000f;
            shellExplosion.m_ExplosionRadius = 20f;
            
        }
        shellInstance.velocity = m_CurrentLaunchForce * m_FireTransform.forward;
        m_ShootingAudio.clip = m_FireClip;
        m_ShootingAudio.Play();
        m_CurrentLaunchForce = m_MinLaunchForce;
    }
}