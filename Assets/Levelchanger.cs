using UnityEngine;
using UnityEngine.SceneManagement;
public class Levelchanger : MonoBehaviour
{
    public Animator animator;

    private int levelToLoad;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            FadeToLevel(1);
        }
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
