using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneFader : MonoBehaviour
{
    public float fadeDuration = 1;

    CanvasGroup m_CanvasGroup;

    void Start ()
    {
        m_CanvasGroup = GetComponentInChildren<CanvasGroup>();

        StartCoroutine(FadeIn());
    }
    public void FadeTo(int scene)
    {
        StartCoroutine(FadeOut());

        SceneManager.LoadScene(scene);
    }

    IEnumerator FadeIn()
    {
        float timer = 1f;

        while (timer > 0f)
        {
            timer -= Time.deltaTime;
            m_CanvasGroup.alpha = timer / fadeDuration;
            yield return 0;
        }
    }
    IEnumerator FadeOut()
    {
        float timer = 0f;

        while (timer < 1f)
        {
            timer += Time.deltaTime;
            m_CanvasGroup.alpha = timer / fadeDuration;
            yield return 0;
        }
    }
}
