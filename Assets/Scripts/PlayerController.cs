using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerController : MonoBehaviour
{
    public float m_PlayerSpeed = 10;
    public float m_ForceJump = 700;

    protected Rigidbody2D m_playerRigid;
    bool m_isJump = false;

    private void Awake()
    {
        m_playerRigid = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        m_playerRigid.velocity = new Vector2(m_PlayerSpeed, m_playerRigid.velocity.y);
    }
    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
            m_isJump = true;
    }
    private void FixedUpdate()
    {
        if (m_isJump)
        {
            Jumping();
            m_isJump = false;
        }
    }
    public abstract void Jumping();
}
