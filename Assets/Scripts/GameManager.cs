using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float playerMoveSpeed = 5f;
    public float playerJumpForce = 170f;
    public int jumpLimit;

    int m_CurrentSceneIndex;

    private void Start()
    {
        m_CurrentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }
    private void Update()
    {
        if (jumpLimit < 0)
        {
            SceneManager.LoadScene(m_CurrentSceneIndex);
        }
    }

    public void ButtonPressed()
    {
        jumpLimit--;
    }
}
