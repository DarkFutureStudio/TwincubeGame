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
    public SceneFader SceneFader;

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
            SceneFader.FadeTo(m_CurrentSceneIndex);
        }
        if (m_TargetHoles == 2)
        {
            //if you won
            if (isWin)
            {
                SceneFader.FadeTo(m_CurrentSceneIndex + 1);
            }
        }
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
