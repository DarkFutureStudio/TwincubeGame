using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 170f;
    public float moveSpeed = 10f;
    public Joystick joystick;

    Rigidbody2D m_Rigidbody;
    float m_HorizontalAxis;

    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        m_HorizontalAxis = joystick.Horizontal;
        Vector2 movement = new Vector2(m_HorizontalAxis * moveSpeed, 0);
        m_Rigidbody.MovePosition(m_Rigidbody.position + movement * Time.deltaTime);
    }

    public void Jump(int index)
    {
        Vector2 jumpDirection;

        if (index == 0)
            jumpDirection = new Vector2(0f, jumpForce);
        else
            jumpDirection = new Vector2(0f, -jumpForce);

        m_Rigidbody.AddForce(jumpDirection);
    }
}
