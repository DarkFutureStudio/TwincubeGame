using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 800;
    public float moveSpeed = 40;

    [Space(4)]
    public LayerMask whatIsGround;
    [Space(4)]

    public Joystick joystick;
    public GameManager gameManager;

    public delegate bool CubesJump();
    public static event CubesJump TriggerJump;

    public delegate void CubesMove(Vector2 movement);
    public static event CubesMove MoveCubes;

    public delegate void Flip();
    public static event Flip TriggerFlip;

    Vector2 m_Move = Vector2.zero;
    bool m_IsJump;
    bool m_FacingRight = true;
    float m_Horizontal;

    public void SetJump() => m_IsJump = true;

    void FixedUpdate()
    {
        if (m_IsJump)
        {
            bool wasJumping = TriggerJump();
            if (wasJumping)
            {
                gameManager.jumpLimit--;
            }
            m_IsJump = false;
        }

        MoveCubes(m_Move);
    }
    void Update()
    {
        m_Horizontal = joystick.Horizontal;

        m_Move = Vector2.right * m_Horizontal * moveSpeed;

        if (m_Horizontal < 0 && m_FacingRight)
            ChangeDirection();
        else if (m_Horizontal > 0 && !m_FacingRight)
            ChangeDirection();
    }
    void ChangeDirection()
    {
        m_FacingRight = !m_FacingRight;
        TriggerFlip();
    }
}
