using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameManager gameManager;
    public Joystick joystick;

    Rigidbody2D m_Rigidbody;
    Vector2 m_JumpDirection;
    float m_HorizontalInput;
    bool m_IsJump;

    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody2D>();

        if (m_Rigidbody.gravityScale < 0)
        {
            gameManager.playerJumpForce = -gameManager.playerJumpForce;
        }
        m_JumpDirection = new Vector2(0f, gameManager.playerJumpForce);
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
        m_HorizontalInput = joystick.Horizontal;
        float xVelocity = m_HorizontalInput * gameManager.playerMoveSpeed;
        m_Rigidbody.velocity = new Vector2(xVelocity, m_Rigidbody.velocity.y);
    }

    public void TriggerJump()
    {
        m_IsJump = true;
    }
}
