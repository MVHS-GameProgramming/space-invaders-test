using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    [SerializeField]
    public float m_LifeSpan = 1f;

    [SerializeField]
    public float m_Speed = 10f;

    private float m_LifeTime;

    private void Start()
    {
        m_LifeTime = m_LifeSpan;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * m_Speed *  Time.deltaTime);
        m_LifeTime -= Time.deltaTime;
        if (m_LifeTime < 0 )
        {
            Destroy(gameObject);
        }
    }
}
