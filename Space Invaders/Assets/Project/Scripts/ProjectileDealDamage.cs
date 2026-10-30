using UnityEngine;

public class ProjectileDealDamage : MonoBehaviour
{

    [SerializeField]
    private float m_DamageAmount;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.LogWarning($"Hit {collision.gameObject}");
        HealthComponent healthComponent = collision.GetComponent<HealthComponent>();
        if (healthComponent != null)
        {
            healthComponent.DealDamage(m_DamageAmount);
            Destroy(gameObject);
        }
        
    }
}
