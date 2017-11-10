using UnityEngine;
using UnityEngine.UI;

public class TankHealth : MonoBehaviour
{
#region Variables
    #region var
    public float m_StartingHealth = 100f;          
    public Slider m_Slider;                        
    public Image m_FillImage;                      
    public Color m_FullHealthColor = Color.green;  
    public Color m_ZeroHealthColor = Color.red;    
    public GameObject m_ExplosionPrefab;
    
   
    private AudioSource m_ExplosionAudio;          
    private ParticleSystem m_ExplosionParticles;
    private float m_CurrentHealth;
    private bool isInvincible;
    
    private bool m_Dead;

    #endregion
    #endregion
    public float CurrentHealth
    {
        get
        {
            return m_CurrentHealth;
        }

        set
        {
            m_CurrentHealth = value;
        }
    }

    public bool IsInvincible
    {
        get
        {
            return isInvincible;
        }

        set
        {
            isInvincible = value;
        }
    }

    private void Awake()
    {
        m_ExplosionParticles = Instantiate(m_ExplosionPrefab).GetComponent<ParticleSystem>();
        m_ExplosionAudio = m_ExplosionParticles.GetComponent<AudioSource>();

        m_ExplosionParticles.gameObject.SetActive(false);
        isInvincible = false;
    }


    private void OnEnable()
    {
        CurrentHealth = m_StartingHealth;
        m_Dead = false;

        SetHealthUI();
    }
 

    public void TakeDamage(float amount)
    {
        if(!isInvincible)
        {
            // Adjust the tank's current health, update the UI based on the new health and check whether or not the tank is dead.
            CurrentHealth -= amount;
            SetHealthUI();
            if (CurrentHealth <= 0f && !m_Dead)
            {
                OnDeath();
            }
        }
       
    }


    private void SetHealthUI()
    {
        // Adjust the value and colour of the slider.
        m_Slider.value = CurrentHealth;
        m_FillImage.color = Color.Lerp(m_ZeroHealthColor, m_FullHealthColor, CurrentHealth / m_StartingHealth);

    }


    private void OnDeath()
    {

        // Play the effects for the death of the tank and deactivate it.
        m_Dead = true;
        m_ExplosionParticles.transform.position = transform.position;
        m_ExplosionParticles.gameObject.SetActive(true);
        m_ExplosionParticles.Play();
        m_ExplosionAudio.Play();
        gameObject.SetActive(false);
    }
}