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
            PlayerController pl = collision.GetComponentInParent<PlayerController>();
            CubeController cube = collision.GetComponent<CubeController>();

            StartCoroutine(Lose(pl, cube));
        }
    }

    IEnumerator Lose(PlayerController playerController, CubeController cube)
    {
        cube.Death();
        playerController.enabled = false;

        yield return new WaitForSeconds(waitForLose);

        gameOver.SetActive(true);

        yield return new WaitForSeconds(waitForLose);

        sceneFader.FadeTo(sceneFader.currentSceneIndex);
    }

    public interface IDisabler
    {
        void OnTriggerEvent();
    }
}
