using UnityEngine;

public class ProjectileDealDamage : MonoBehaviour
{

    [SerializeField]
    private float m_DamageAmount;

    [SerializeField]
    private GameObject m_ImpactParticles;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        HealthComponent healthComponent = collision.GetComponent<HealthComponent>();
        if (healthComponent != null)
        {
            healthComponent.DealDamage(m_DamageAmount);
            Instantiate(m_ImpactParticles, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        
    }
}
