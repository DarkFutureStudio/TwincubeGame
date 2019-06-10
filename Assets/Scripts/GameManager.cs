using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int jumpLimit;
    public bool isWin;
    public SceneFader sceneFader;
    public GameObject winCanvas;

    int m_TargetHoles;

    private void Awake()
    {
        sceneFader.gameObject.SetActive(true);
    }
    private void Update()
    {
        if (jumpLimit < 0)
        {
            //In case you lose loading current scene
            sceneFader.FadeTo(sceneFader.currentSceneIndex);
        }
        if (m_TargetHoles == 2)
        {
            //In case you win load next level
            winCanvas.SetActive(true);
        }
    }


    public void IncreamentTarget() => m_TargetHoles++;
}
