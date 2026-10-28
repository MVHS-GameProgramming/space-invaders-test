using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerFire : MonoBehaviour
{
    [SerializeField]
    public GameObject m_ProjectilePrefab;

    [SerializeField]
    public Transform m_FirePosition;

    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Instantiate(m_ProjectilePrefab, m_FirePosition.position, Quaternion.identity);
        }
    }
}
