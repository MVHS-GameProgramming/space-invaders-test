using System;
using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    [SerializeField]
    private float m_MaxHealth;

    [SerializeField]
    private float m_StartingHealth;

    [SerializeField]
    private GameObject m_DieVFX;

    public float CurrentHealth { get; private set; }
    public float MaxHealth {  get { return m_MaxHealth; } }

    public bool IsDead { get; private set; }

    public static event Action<HealthComponent> OnDied;

    public event Action<float, float> OnHealthChange;

    private void Awake()
    {
        CurrentHealth = m_StartingHealth;
        IsDead = CurrentHealth <= 0f;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CurrentHealth = m_StartingHealth;
        IsDead = CurrentHealth <= 0f;
    }


    public void DealDamage(GameObject damageDealer, float amount)
    {

        CurrentHealth -= amount;
        CurrentHealth = Mathf.Clamp(CurrentHealth - amount, 0f, m_StartingHealth);
        OnHealthChange?.Invoke(CurrentHealth, m_MaxHealth);

        if (CurrentHealth <= 0)
        {
            IsDead = true;
            OnDied?.Invoke(this);

            if (m_DieVFX != null)
            {
                Instantiate(m_DieVFX, transform.position, Quaternion.identity);
            }
            
            Destroy(gameObject);
        }
    }


}
