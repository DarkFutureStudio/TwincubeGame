using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;


public class Winpanel : MonoBehaviour
{
    public Button[] levelselect;
    public SceneFader fader;

    public void Select(int levelIndex)
    {
        fader.FadeTo(levelIndex);
    }
    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
