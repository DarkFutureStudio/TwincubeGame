using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 800;
    public float moveSpeed = 40;
    public LayerMask whatIsGround;
    public Joystick joystick;
    public GameManager gameManager;
    public bool useKeyboard;

    public delegate bool CubesJump();
    public static event CubesJump TriggerJump;

    public delegate void CubesMove(Vector2 movement);
    public static event CubesMove MoveCubes;

    Vector2 m_MoveHorizontal = Vector2.zero;
    bool m_IsJump;


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

        MoveCubes(m_MoveHorizontal);
    }
    void Update()
    {
        //calculate movement...
        float horizontalInput;

        if (useKeyboard)
        {
            horizontalInput = Input.GetAxis("Horizontal");

            if (Input.GetKeyDown(KeyCode.Space))
                SetJump();
        }
        else
            horizontalInput = joystick.Horizontal;

        m_MoveHorizontal = Vector2.right * horizontalInput * moveSpeed;
    }

}
