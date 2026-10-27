using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float m_Speed = 5f;
    

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
        transform.Translate(moveInput * m_Speed * Time.deltaTime);
    }
}
