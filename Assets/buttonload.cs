using UnityEngine;
using UnityEngine.SceneManagement;
public class buttonload : MonoBehaviour
{
    public string LevelToLoad = "";
    public string LevelToLoad1 = "";

    public SceneFader sceneFader;
    public void b1()
    {
        sceneFader.FadeTo(LevelToLoad);
    }
    public void b2()
    {
        sceneFader.FadeTo(LevelToLoad1);
    }
}
