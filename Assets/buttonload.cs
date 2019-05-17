using UnityEngine;
using UnityEngine.SceneManagement;
public class buttonload : MonoBehaviour
{
    public string LevelToLoad = "Level 1";
    public string LevelToLoad1 = "Level 2";
    public string LevelToLoad2 = "Level 3";
    public string LevelToLoad3 = "Level 4";
    public string LevelToLoad4 = "Level 5";

    public SceneFader sceneFader;
    public void b()
    {
        sceneFader.FadeTo(LevelToLoad);
    }
    public void b1()
    {
        sceneFader.FadeTo(LevelToLoad1);
    }
    public void b2()
    {
        sceneFader.FadeTo(LevelToLoad2);
    }
    public void b3()
    {
        sceneFader.FadeTo(LevelToLoad3);
    }
    public void b4()
    {
        sceneFader.FadeTo(LevelToLoad4);
    }
}
