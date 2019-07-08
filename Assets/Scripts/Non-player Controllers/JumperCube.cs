using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumperCube : MonoBehaviour
{
    public Vector2 targetPoint = Vector2.zero;
    public float speed;

    Rigidbody2D m_Rigidbody;
    readonly Vector3[] m_TargetPoints = new Vector3[2];
    int m_CurrentTarget;

    private void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody2D>();

        m_TargetPoints[0] = transform.position;
        m_TargetPoints[1] = transform.position + (Vector3)targetPoint;

        m_CurrentTarget = 1;
    }
    private void FixedUpdate()
    {
        Vector2 target = Vector2.MoveTowards
            (transform.position, m_TargetPoints[m_CurrentTarget], speed * Time.deltaTime);

        m_Rigidbody.MovePosition(target);

        if (transform.position == m_TargetPoints[m_CurrentTarget])
        {
            m_CurrentTarget = (m_CurrentTarget + 1) % 2;

            if (m_CurrentTarget == 0)
                speed *= 2;
            else
                speed /= 2;
        }
    }
    private void OnDrawGizmosSelected()
    {
        if (!UnityEditor.EditorApplication.isPlaying)
        {
            Gizmos.color = Color.red;
            Vector3 target = transform.position + (Vector3)targetPoint;
            Gizmos.DrawLine(transform.position, target);
        }
    }
}
