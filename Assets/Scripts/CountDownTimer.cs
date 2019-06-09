﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDownTimer : MonoBehaviour
{
    public SceneFader sceneFader;
    public Text countdownText;
    public float startTime = 60;
    public int pickupTime = 5;

    float m_CurrentTime = 0f;
    private void Start()
    {
        m_CurrentTime = startTime;
    }
    void Update()
    {
        m_CurrentTime -= Time.deltaTime;
        countdownText.text = m_CurrentTime.ToString ("00");

        if (m_CurrentTime <= 0)
        {
            sceneFader.FadeTo(sceneFader.currentSceneIndex);
        }
    }

    public void IncreaseTime() => m_CurrentTime += pickupTime;
}
