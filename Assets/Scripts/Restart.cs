using UnityEngine.SceneManagement;

public class Restart
{
    public void RestartScene()
    {
        //restart values
        TriggerWin.m_counter = 0;

        //restart the current scene(level)
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
