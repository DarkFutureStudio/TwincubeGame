using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumperCube : MonoBehaviour
{
    public Transform reachPoint;
    public float speed;

    Rigidbody2D m_Rigidbody;
    Vector2 m_FirstPosition;
    Vector2 m_Target;

    private void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody2D>();

        m_FirstPosition = transform.position;
    }
    private void FixedUpdate()
    {
        Vector2 target = Vector2.MoveTowards
            (transform.position, m_Target, speed * Time.deltaTime);

        m_Rigidbody.MovePosition(target);

        if (transform.position == reachPoint.position)
        {
            m_Target = m_FirstPosition;
        }
        else if (transform.position == (Vector3)m_FirstPosition)
        {
            m_Target = reachPoint.position;
        }
    }
}
