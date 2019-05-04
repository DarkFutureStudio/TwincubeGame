using UnityEngine;
using UnityEngine.SceneManagement;
public class Mainmenu : MonoBehaviour
{
    public string LevelToLoad = "Mainlevel";

    public SceneFader sceneFader;
    public void Play ()
    {
        sceneFader.FadeTo(LevelToLoad);
    }
    public void Quit ()
    {
        Debug.Log("Exiting");
        Application.Quit();
    }
}
