using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
public class CubeController : MonoBehaviour
{
    public GameObject groundCheck;

    Rigidbody2D m_Rigidbody;
    Vector2 m_JumpDirection = Vector2.up;
    float m_HorizontalAxis = 0;

    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody2D>();

        m_JumpDirection = SetJumpDirection();
    }
    Vector2 SetJumpDirection()
    {
        float jumpForce;

        if (m_Rigidbody.gravityScale > 0)
        {
            jumpForce = controller.jumpForce;
        }
        else
        {
            jumpForce = -controller.jumpForce;
        }

        return Vector2.up * jumpForce;
    }
    void Jump()
    {
        m_Rigidbody.AddForce(m_JumpDirection);
    }
}
