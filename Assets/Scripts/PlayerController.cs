using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 700;
    public float moveSpeed = 10;
    public int jumpLimit = 6;
    public Joystick joystick;

    Rigidbody2D[] m_Player = new Rigidbody2D[2];
    float m_HorizontalInput = 0;
    Restart m_GameReset = new Restart();

    void Awake()
    {
        //get players rigidbody in children...
        for (int i = 0; i < transform.childCount; i++)
        {
            m_Player[i] = transform.GetChild(i).GetComponent<Rigidbody2D>();
        }
    }    
    void FixedUpdate()
    {
        m_HorizontalInput = joystick.Horizontal;
        //move the players...
        transform.Translate(new Vector2(m_HorizontalInput * moveSpeed * Time.fixedDeltaTime, 0));
    }
    
    public void Jumping()
    {
        m_Player[0].AddForce(new Vector2(0, jumpForce));
        m_Player[1].AddForce(new Vector2(0, -jumpForce));

        jumpLimit--;
        if (jumpLimit == 0)
            m_GameReset.RestartScene();
    }
}