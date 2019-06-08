using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
public class CubeController : MonoBehaviour
{
    public Transform groundCheck;
    public Vector2 boxSize;

    PlayerController m_PlayerController;
    Rigidbody2D m_Rigidbody;
    Vector2 m_JumpDirection = Vector2.up;

    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody2D>();
        m_PlayerController = GetComponentInParent<PlayerController>();

        m_JumpDirection = SetJumpDirection();
    }
    Vector2 SetJumpDirection()
    {
        //determine what direction should we jump
        float jumpForce = m_PlayerController.jumpForce;

        if (m_Rigidbody.gravityScale < 0)
            jumpForce = -jumpForce;

        return Vector2.up * jumpForce;
    }
    bool Jump()
    {
        bool onGround = Physics2D.OverlapBox
            (groundCheck.position, boxSize, 0, m_PlayerController.whatIsGround);

        if (!onGround)
            return false;

        m_Rigidbody.AddForce(m_JumpDirection);
        return true;
    }
    void Move(Vector2 movement) => m_Rigidbody.AddForce(movement);

    private void OnEnable()
    {
        PlayerController.TriggerJump += Jump; //Add funtion to the event
        PlayerController.MoveCubes += Move;
    }
    private void OnDisable()
    {
        PlayerController.TriggerJump -= Jump; //remove function from the event
        PlayerController.MoveCubes -= Move;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(groundCheck.position, boxSize);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Time"))
        {
            Destroy(other.gameObject);
        }
    }
}
