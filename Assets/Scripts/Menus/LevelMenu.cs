using UnityEngine;
using UnityEngine.UI;

public class LevelMenu : MonoBehaviour
{
    public GameObject levelCanvas;
    public bool lockLevel;

    Button[] buttons;

    void Start ()
    {
        buttons = levelCanvas.GetComponentsInChildren<Button>();

        if (lockLevel)
        {
            //A file that saves the player progress
            int levelReached = PlayerPrefs.GetInt("levelReached", 1);

            //Disable levels when player doesn't reached them
            for (int i = 0; i < buttons.Length; i++)
            {
                if (i >= levelReached)
                {
                    buttons[i].interactable = false;
                }
            }
        }
    }
}
