using UnityEngine;
using UnityEngine.SceneManagement;
public class Levelchanger : MonoBehaviour
{
    public Animator animator;

    private int levelToLoad;

    private void OnMouseDown()
    {
        FadeToNextLevel();
    }

    public void FadeToNextLevel ()
    {
        FadeToLevel(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void FadeToLevel (int levelIndex)
    {
        levelToLoad = levelIndex; 
        animator.SetTrigger("Fadeout");
    }

    public void Onfadecomplete ()
    {
        SceneManager.LoadScene(levelToLoad);
    }

}
