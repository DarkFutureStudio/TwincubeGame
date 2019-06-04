using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 800;
    public float moveSpeed = 40;
    public Joystick joystick;
    public LayerMask whatIsGround;

    public static event Cubes 

    float m_HorizontalInput;
    bool m_IsJump;

    delegate void Cubes();


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
        Collider2D[] grounded = Physics2D.OverlapCircleAll(groundCheck.position, .15f, whatIsGround);
        foreach (Collider2D col in grounded)
        {
            if (col.gameObject == gameObject)
                continue;

            m_IsJump = true;
        }
    }
}
