using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneFader : MonoBehaviour
{
    [Range(0f, 3f)] //We will not increase fadeDuration further than '3' for sure
    public float fadeDuration = 1;
    public CanvasGroup canvasGroup;


    private void Awake()
    {
        gameObject.SetActive(true);
        Debug.Log("Awake called");
    }
    void Start ()
    {
        //Every scene with load will fade out
        StartCoroutine(FadeIn());
    }

    public void FadeTo(int scene)
    {
        StartCoroutine(FadeOut(scene));
    }

    IEnumerator FadeIn()
    {
        float timer = 1f;

        while (timer > 0)
        {
            timer -= Time.deltaTime;
            canvasGroup.alpha = timer / fadeDuration; //Changin opacity
            yield return 0;
        }
    }
    IEnumerator FadeOut(int scene)
    {
        float timer = 0f;

        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            canvasGroup.alpha = timer / fadeDuration;
            yield return 0;
        }

        SceneManager.LoadScene(scene);
    }
}
