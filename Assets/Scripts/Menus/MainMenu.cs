﻿using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public SceneFader sceneFader;

    public void Play()
    {
        sceneFader.FadeTo(1);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
