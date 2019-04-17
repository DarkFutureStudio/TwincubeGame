using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float m_JumpForce = 700;
    public float m_MoveSpeed = 10;

    Rigidbody2D[] m_player = new Rigidbody2D[2];
    bool m_isJump = false;
    float m_horizontalInput = 0;

    private void Awake()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            m_player[i] = transform.GetChild(i).GetComponent<Rigidbody2D>();
        }
    }
    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
            m_isJump = true;
        m_horizontalInput = Input.GetAxis("Horizontal");
    }
    private void FixedUpdate()
    {
        if (m_isJump)
        {
            Jumping();
            m_isJump = false;
        }

        transform.Translate(new Vector2(m_horizontalInput * m_MoveSpeed * Time.fixedDeltaTime, 0));
    }
    
    void Jumping()
    {
        m_player[0].AddForce(new Vector2(0, m_JumpForce));
        m_player[1].AddForce(new Vector2(0, -m_JumpForce));
    }
}