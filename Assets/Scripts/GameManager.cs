using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public SceneFader sceneFader;
    public GameObject winCanvas, touchController;
    public PlayerController pl;
    [Space(6)]
    public MonoBehaviour[] whatShouldDisable;

    [HideInInspector] public int targetWin = 0;

    private void Awake()
    {
        sceneFader.gameObject.SetActive(true);
        new Disabler(whatShouldDisable);
    }
    private void Update()
    {
        if (targetWin == 2)
        {
            //In case you win load next level
            Disabler.OnEventDisable();

            Destroy(touchController);

            winCanvas.SetActive(true);
        }
    }
}
