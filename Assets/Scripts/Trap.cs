using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    public int waitForLose = 1;
    public GameObject gameOver;
    public PlayerController playerController;
    public SceneFader sceneFader;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            StartCoroutine(Lose());
    }

    IEnumerator Lose()
    {
        gameOver.SetActive(true);
        playerController.enabled = false;

        yield return new WaitForSeconds(waitForLose);

        sceneFader.FadeTo(sceneFader.currentSceneIndex);
    }

    public interface IDisabler
    {
        void OnTriggerEvent();
    }
}
