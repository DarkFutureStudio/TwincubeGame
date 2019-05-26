using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneFader : MonoBehaviour
{
    [Range(0f, 3f)]
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

        while (timer > 0)
        {
            timer -= Time.deltaTime;
            m_CanvasGroup.alpha = timer / fadeDuration;
            yield return 0;
        }
    }
    IEnumerator FadeOut()
    {
        float timer = 0f;

        while (timer < 1)
        {
            timer += Time.deltaTime;
            m_CanvasGroup.alpha = timer / fadeDuration;
            yield return 0;
        }
    }
}
