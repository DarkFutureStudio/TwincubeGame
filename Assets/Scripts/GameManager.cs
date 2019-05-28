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
    public bool useKeyboard;
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
            //In case you lose loading current scene
            SceneFader.FadeTo(m_CurrentSceneIndex);
        }
        if (m_TargetHoles == 2)
        {
            //In case you win load next level
            if (isWin)
            {
                SceneFader.FadeTo(m_CurrentSceneIndex + 1);
            }
        }
    }

    public void ButtonPressed() //Pressing 'jump' button reduce jumpCount
    {
        jumpLimit--;
    }
    public void IncreamentTarget() //Put targets in holes will call this function
    {
        m_TargetHoles++;
    }
}
