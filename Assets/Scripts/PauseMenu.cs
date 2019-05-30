using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu: MonoBehaviour
{
    public SceneFader scenefader;
    public GameObject pauseCanvas;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Toggle();
        }
    }

    public void Toggle()
    {
        pauseCanvas.SetActive(!pauseCanvas.activeSelf);

        //time scale will 1 or 0
        Time.timeScale = ((int)Time.timeScale + 1) % 2;
    }
    public void Retry()
    {
        Toggle();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Select (int levelIndex)
    {
        Toggle();
        scenefader.FadeTo(levelIndex);
    }
}
