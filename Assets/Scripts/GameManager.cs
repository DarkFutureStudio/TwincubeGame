using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool GameIsOver;

    public GameObject gameOverUI;

     void Start()
    {
        GameIsOver = false;
    }

     void Update()
    {
        if (GameIsOver)
            return;

     //   if ()
        {
            EndGame();
        }

        void EndGame()
        {
            GameIsOver = true;
            gameOverUI.SetActive(true);
        }
    }
}
