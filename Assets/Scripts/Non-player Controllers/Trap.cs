using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    public int waitForLose = 1;
    public GameObject gameOver;
    public SceneFader sceneFader;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Disabler.OnEventDisable();

            CubeController cubeController = collision.GetComponent<CubeController>();
            StartCoroutine(Lose(cubeController));
        }
    }

    IEnumerator Lose(CubeController cube)
    {
        cube.Death();

        yield return new WaitForSeconds(waitForLose);

        gameOver.SetActive(true);

        yield return new WaitForSeconds(waitForLose);

        sceneFader.FadeTo(sceneFader.currentSceneIndex);
    }
}
public class Disabler
{
    public Disabler(MonoBehaviour[] scripts)
    {
        m_WhatToDisable = scripts ?? throw new System.ArgumentNullException();
    }

    static MonoBehaviour[] m_WhatToDisable;

    public static void OnEventDisable()
    {
        foreach (var item in m_WhatToDisable)
        {
            item.enabled = false;
        }
    }
}