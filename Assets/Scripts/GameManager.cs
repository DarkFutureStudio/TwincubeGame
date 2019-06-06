using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int jumpLimit;
    public bool isWin;
    public SceneFader sceneFader;

    int m_CurrentSceneIndex;
    int m_TargetHoles;

    private void Awake()
    {
        sceneFader.gameObject.SetActive(true);
    }
    private void Start()
    {
        m_CurrentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }
    private void Update()
    {
        if (jumpLimit < 0)
        {
            //In case you lose loading current scene
            sceneFader.FadeTo(m_CurrentSceneIndex);
        }
        if (m_TargetHoles == 2)
        {
            //In case you win load next level
            if (isWin)
            {
                sceneFader.FadeTo(m_CurrentSceneIndex + 1);
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
