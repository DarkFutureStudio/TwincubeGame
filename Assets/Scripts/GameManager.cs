using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float playerMoveSpeed = 5f;
    public float playerJumpForce = 170f;
    public int jumpLimit;
    public bool isWin;

    int m_CurrentSceneIndex;
    int m_TargetHoles;

    private void Start()
    {
        m_CurrentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }
    private void Update()
    {
        if (jumpLimit < 0)
        {
            //if you lose
            LoadLevel(m_CurrentSceneIndex);
        }
        if (m_TargetHoles == 2)
        {
            //if you won
            if (isWin)
            {
                LoadLevel(m_CurrentSceneIndex + 1);
            }
        }
    }

    void LoadLevel(int level)
    {
        SceneManager.LoadScene(level);
    }

    public void ButtonPressed()
    {
        jumpLimit--;
    }
    public void IncreamentTarget()
    {
        m_TargetHoles++;
    }
}
