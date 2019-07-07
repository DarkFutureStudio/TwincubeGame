using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class DynamicTrap : Trap
{
    public float moveSpeed = 3; //How fast should we reach each point
    public float turnSpeed = 1.5f; //How fast should turn
    public float dynamicRange = 4f; //the whole range trap should move
    [Range(0, 1)]
    public float disposedChannel = .5f; //how long should go left or right

    Rigidbody2D m_Rigidbody;
    readonly Vector2[] m_Targets = new Vector2[2];
    int m_CurrentTarget, m_PreviousTarget = 0;

    private void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody2D>();

        SetupTargets();
    }
    void SetupTargets()
    {
        float leftRange = dynamicRange * disposedChannel; //Calculate how much space left-range need
        float rightRange = dynamicRange - leftRange; //What remains is the right space

        m_Targets[0] = m_Rigidbody.position - (Vector2.right * leftRange);
        m_Targets[1] = m_Rigidbody.position + (Vector2.right * rightRange);
    }
    private void FixedUpdate()
    {
        Move();

        Rotate();
    }
    void Rotate()
    {
        bool targetChanged = m_PreviousTarget != m_CurrentTarget;
        if (targetChanged)
        {
            turnSpeed = -turnSpeed;
            m_PreviousTarget = m_CurrentTarget;
        }

        transform.Rotate(0, 0, turnSpeed);
    }
    void Move()
    {
        Vector2 movement = Vector2.MoveTowards
            (transform.position, m_Targets[m_CurrentTarget], moveSpeed * Time.deltaTime);

        m_Rigidbody.MovePosition(movement);

        if (transform.position == (Vector3)m_Targets[m_CurrentTarget])
            m_CurrentTarget = (m_CurrentTarget + 1) % 2;
    }
}
