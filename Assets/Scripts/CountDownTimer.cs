using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDownTimer : MonoBehaviour
{
    public SceneFader sceneFader;
    public Text countdownText;

    float currentTime = 0f;
    readonly float startTime = 60f;
    private void Start()
    {
        currentTime = startTime;
    }
    void Update()
    {
        currentTime -= Time.deltaTime;
        countdownText.text = currentTime.ToString ("00");

        if (currentTime <= 0)
        {
            sceneFader.FadeTo(sceneFader.currentSceneIndex);
        }
    }

    public void IncreaseTime(int Timevalue) => currentTime += Timevalue;
}
