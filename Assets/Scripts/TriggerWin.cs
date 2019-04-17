using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerWin : MonoBehaviour
{
    public GameObject m_WinCanv;

    static int m_counter = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Finish"))
            m_counter++;
    }
    private void LateUpdate()
    {
        if (m_counter == 2)
            m_WinCanv.SetActive(true);
    }
}
