using UnityEngine;

public class PlayerCollisionDetector : MonoBehaviour
{

    [SerializeField]
    HealthComponent m_HealthComponent;



    public void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject otherGameObject = collision.gameObject;
        if (otherGameObject != null && otherGameObject.CompareTag("Enemy"))
        {
            // Deal damage to self (player)
            m_HealthComponent.DealDamage(otherGameObject, 40);

            // Deal damage to enemy ship to destroy it
            HealthComponent enemyHealthComponent = otherGameObject.GetComponent<HealthComponent>();
            if (enemyHealthComponent != null)
            {
                enemyHealthComponent.DealDamage(gameObject, 500);
            }
        }
    }


}
