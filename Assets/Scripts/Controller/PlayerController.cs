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

    public delegate void Triggers();
    public delegate void CubesMove(Vector2 movement);

    public static event Triggers TriggerJump;
    public static event CubesMove MoveCubes;
    public static event Triggers TriggerFlip;

    Vector2 m_Move = Vector2.zero;
    bool m_IsJump;
    bool m_FacingRight = true;

    public void SetJump() => m_IsJump = true;

    void FixedUpdate()
    {
        if (m_IsJump)
        {
            TriggerJump();
            m_IsJump = false;
        }

        MoveCubes(m_Move);
    }
    void Update()
    {
        float input = joystick.Horizontal;

        m_Move = Vector2.right * input * moveSpeed;

        if (input < 0 && m_FacingRight)
            ChangeDirection();
        else if (input > 0 && !m_FacingRight)
            ChangeDirection();
    }
    void ChangeDirection()
    {
        m_FacingRight = !m_FacingRight;
        TriggerFlip();
    }
}
