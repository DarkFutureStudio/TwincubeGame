using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;


public class winpanel : MonoBehaviour
{
    public Button[] levelselect;
    public SceneFader fader;

    public void Select(int levelIndex)
    {
        fader.FadeTo(levelIndex);
    }
  
    public void retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
