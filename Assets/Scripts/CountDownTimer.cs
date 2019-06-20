using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDownTimer : MonoBehaviour
{
    public SceneFader sceneFader;
    public Text countdownText;
    public float startTime = 60;
    public int pickupTime = 5;
    public string sensitiveTime = "05";

    float m_CurrentTime = 0f;
    bool m_SensitiveMode = false;

    private void Start()
    {
        m_CurrentTime = startTime;
    }
    void Update()
    {
        m_CurrentTime -= Time.deltaTime;
        countdownText.text = m_CurrentTime.ToString("00");

        if (m_CurrentTime <= 0)
        {
            sceneFader.FadeTo(sceneFader.currentSceneIndex);
        }

        if (countdownText.text.Equals(sensitiveTime) && !m_SensitiveMode)
        {
            m_SensitiveMode = true;
            countdownText.fontSize = 70;
            countdownText.color = Color.red;
        }
        else if 
            (Convert.ToInt32(countdownText.text) > Convert.ToInt32(sensitiveTime) && m_SensitiveMode)
        {
            m_SensitiveMode = false;
            countdownText.fontSize = 30;
            countdownText.color = Color.white;
        }
    }

    public void IncreaseTime() => m_CurrentTime += pickupTime;
}
