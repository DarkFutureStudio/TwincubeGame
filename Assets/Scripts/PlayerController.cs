using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float m_PlayerSpeed = 10;
    public float m_ForceJump = 700;

    GameObject[] m_players;
    bool m_isJump = false;

    private void Awake()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            m_players[i] = transform.GetChild(i).gameObject;
        }
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
