using System;
using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    [SerializeField]
    public float m_MaxHealth;

    [SerializeField]
    public float m_StartingHealth;

    [SerializeField]
    private GameObject m_DieVFX;

    public float CurrentHealth { get; private set; }

    public bool IsDead { get; private set; }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CurrentHealth = m_StartingHealth;
        IsDead = CurrentHealth <= 0f;
    }


    public void DealDamage(GameObject damageDealer, float amount)
    {

        CurrentHealth -= amount;
        Debug.Log($"{damageDealer} delt {amount} damage to {gameObject}");
        if (CurrentHealth < 0)
        {
            CurrentHealth = 0f;
            IsDead = true;

            if (m_DieVFX != null)
            {
                Instantiate(m_DieVFX, transform.position, Quaternion.identity);
            }
            
            Destroy(gameObject);
        }
    }


}
