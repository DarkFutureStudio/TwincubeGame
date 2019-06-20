using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int jumpLimit;
    public SceneFader sceneFader;
    public GameObject winCanvas;
    public PlayerController pl;
    public MonoBehaviour[] whatShouldDisable;

    [HideInInspector] public int targetWin = 0;

    private void Awake()
    {
        sceneFader.gameObject.SetActive(true);
        new Disabler(whatShouldDisable);
    }
    private void Update()
    {
        if (jumpLimit < 0)
        {
            //In case you lose loading current scene
            sceneFader.FadeTo(sceneFader.currentSceneIndex);
        }
        if (targetWin == 2)
        {
            //In case you win load next level
            Disabler.OnEventDisable();
            winCanvas.SetActive(true);
        }
    }
}
