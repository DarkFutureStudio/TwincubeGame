using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
public class PlayerController : MonoBehaviour
{
    public GameManager gameManager;
    public Vector2 boxSize;
    public Joystick joystick;
    public Transform groundCheck;
    public LayerMask whatIsGround;

    Rigidbody2D m_Rigidbody;
    Vector2 m_JumpDirection;
    float m_HorizontalInput;
    bool m_IsJump;


    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody2D>();

        //Determines what direction should player jump
        float jumpForce;
        if (m_Rigidbody.gravityScale < 0)
        {
            jumpForce = -gameManager.playerJumpForce;
        }
        else
        {
            jumpForce = gameManager.playerJumpForce;
        }

        m_JumpDirection = new Vector2(0f, jumpForce);
    }
    void Update()
    {
        if (gameManager.useKeyboard)
        {
            m_HorizontalInput = Input.GetAxis("Horizontal");
            if (Input.GetKeyDown(KeyCode.Space))
            {
                TriggerJump();
            }

            return;
        }

        m_HorizontalInput = joystick.Horizontal;
    }
    void FixedUpdate()
    {
        if (m_IsJump)
        {
            m_Rigidbody.AddForce(m_JumpDirection);
            m_IsJump = false;
        }

        Move();
    }

    void Move()
    {
        float horizontalMovement = m_HorizontalInput * gameManager.playerMoveSpeed;
        Vector2 movement = new Vector2(horizontalMovement, 0f);
        m_Rigidbody.AddForce(movement);
    }

    public void TriggerJump() //Call with button event
    {
        bool grounded = Physics2D.OverlapBox(groundCheck.position, boxSize, 0, whatIsGround);
        if (grounded)
        {
            m_IsJump = true;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(groundCheck.position, boxSize);
    }
}
