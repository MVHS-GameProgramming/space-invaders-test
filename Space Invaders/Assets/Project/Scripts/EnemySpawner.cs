using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject m_EnemyPrefab;

    [SerializeField]
    private float m_SpawnInterval;

    private float m_TimeTillNextSpawn;

    bool m_CanSpawn = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_TimeTillNextSpawn = m_SpawnInterval;
    }

    // Update is called once per frame
    void Update()
    {
        m_TimeTillNextSpawn -= Time.deltaTime;
        if (m_TimeTillNextSpawn < 0 && m_CanSpawn)
        {
            m_CanSpawn = false;
            m_TimeTillNextSpawn = m_SpawnInterval;
            SpawnEnemy();
        }
    }

    public void SpawnEnemy()
    {
        Instantiate<GameObject>(m_EnemyPrefab, transform.position, Quaternion.identity);
    }
}
