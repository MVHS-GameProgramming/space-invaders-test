using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float m_Accel = 9f;

    [SerializeField]
    private float m_Drag = 2.8f;

    [SerializeField]
    public float m_LeftScreenBounds = -2.45f;

    [SerializeField]
    public float m_RightScreenBounds = 2.45f;

    private Vector2 m_Velocity = Vector2.zero;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveInput = getMoveInput();
        move(moveInput);
    }

    public Vector2 getMoveInput()
    {
        Vector2 moveInput = Vector2.zero;
        if (Keyboard.current.aKey.IsPressed() || Keyboard.current.leftArrowKey.IsPressed())
        {
            moveInput.x -= 1f;
        }
        if (Keyboard.current.dKey.IsPressed() || Keyboard.current.rightArrowKey.IsPressed())
        {
            moveInput.x += 1f;
        }
        return moveInput.normalized;
    }

    public void move(Vector2 moveInput)
    {
        m_Velocity += moveInput * m_Accel * Time.deltaTime;
        m_Velocity -= m_Velocity * m_Drag * Time.deltaTime;

        Vector2 oldPosition = new Vector2(transform.position.x, transform.position.y);
        Vector2 newPosition = oldPosition + m_Velocity * Time.deltaTime;


        if (newPosition.x < m_LeftScreenBounds || newPosition.x > m_RightScreenBounds)
        {
            m_Velocity = Vector2.zero;
            newPosition.x = Mathf.Clamp(newPosition.x, m_LeftScreenBounds, m_RightScreenBounds);
        }

        transform.position = new Vector3(newPosition.x, newPosition.y, 0);
    }
}
