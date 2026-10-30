

using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject m_EnemyPrefab;

    [SerializeField]
    private float m_MinSpawnInterval;

    [SerializeField]
    private float m_MaxSpawnInterval;

    [SerializeField]
    private float m_SpawnWidthSpan = 1;



    private float m_TimeTillNextSpawn;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_TimeTillNextSpawn = Random.Range(m_MinSpawnInterval, m_MaxSpawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        m_TimeTillNextSpawn -= Time.deltaTime;
        if (m_TimeTillNextSpawn < 0)
        {
            m_TimeTillNextSpawn = Random.Range(m_MinSpawnInterval, m_MaxSpawnInterval);
            SpawnEnemy();
        }
    }

    public void SpawnEnemy()
    {
        Vector3 spawnPosition = transform.position;
        float spawnXOffset = Random.Range(-m_SpawnWidthSpan, m_SpawnWidthSpan);
        spawnPosition.x = spawnXOffset;

        Instantiate(m_EnemyPrefab, spawnPosition, Quaternion.identity);
    }

    public void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;

        Vector3 leftSpawnEnd = transform.position - Vector3.right * m_SpawnWidthSpan;
        Vector3 rightSpawnEnd = transform.position + Vector3.right * m_SpawnWidthSpan;
        Gizmos.DrawLine(leftSpawnEnd, rightSpawnEnd);
    }
}
