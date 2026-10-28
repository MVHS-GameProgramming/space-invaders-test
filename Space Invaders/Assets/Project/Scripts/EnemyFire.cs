using UnityEngine;

public class EnemyFire : MonoBehaviour
{
    [SerializeField]
    private float m_MinFireDelay;

    [SerializeField]
    private float m_MaxFireDelay;

    [SerializeField]
    private GameObject m_ProjectilePrefab;

    [SerializeField]
    private Transform m_FirePosition;

    private float m_TimeToNextFire;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_TimeToNextFire = Random.Range(m_MinFireDelay, m_MaxFireDelay);
    }

    // Update is called once per frame
    void Update()
    {
        m_TimeToNextFire -= Time.deltaTime;
        if (m_TimeToNextFire < 0)
        {
            FireProjectile();
            m_TimeToNextFire = Random.Range(m_MinFireDelay, m_MaxFireDelay);
        }
      
    }

    private void FireProjectile()
    {
        GameObject projectile = Instantiate(m_ProjectilePrefab, m_FirePosition.position, Quaternion.identity);
        ProjectileMovement projectileMovement = projectile.GetComponent<ProjectileMovement>();
        if (projectileMovement != null)
        {
            projectileMovement.MoveDirection = Vector2.down;
        }
    }


}
