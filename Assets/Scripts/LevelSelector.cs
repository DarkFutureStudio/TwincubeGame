using UnityEngine;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
   public Button[] levelButtons;
    public bool lockLevel;

   void Start ()
   {
        if (!lockLevel)
            return;

        int levelReached = PlayerPrefs.GetInt("levelReached", 1);

        for (int i = 0; i < levelButtons.Length; i++)
        {
            if (i >= levelReached)
            {
                levelButtons[i].interactable = false;
            }
        }
   }
}
