using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneFader : MonoBehaviour
{
    public AnimationCurve curve;
    public Image image;

    void Start ()
    {
        StartCoroutine(FadeIn());
    }
    public void FadeTo (int scene)
    {
        StartCoroutine(FadeOut());

        SceneManager.LoadScene(scene);
    }

    IEnumerator FadeIn ()
    {
        float t = 1f;

        while (t > 0f)
        {
            t -= Time.deltaTime;
            float a = curve.Evaluate(t); 
            image.color = new Color (0f ,0f ,0f , a);
            yield return 0;
        }
    }
    IEnumerator FadeOut()
    {
        float t = 0f;

        while (t < 1f)
        {
            t += Time.deltaTime;
            float a = curve.Evaluate(t);
            image.color = new Color(0f, 0f, 0f, a);
            yield return 0;
        }
    }
}
