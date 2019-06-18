using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    public int waitForLose = 1;
    public GameObject gameOver;
    public SceneFader sceneFader;
    public MonoBehaviour[] whatShouldDisable;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
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

    public static void Disabler()
    {
        foreach (var in whatShouldDisable)
    }
}
