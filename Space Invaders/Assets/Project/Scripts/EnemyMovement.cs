using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    [SerializeField]
    private float m_Speed = 3.5f;

    [SerializeField]
    private float m_LifeSpan = 4f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject, m_LifeSpan);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * m_Speed * Time.deltaTime);
    }
}
