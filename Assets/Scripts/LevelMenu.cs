using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelMenu : MonoBehaviour
{
    public Button[] buttons;

    // Start is called before the first frame update
    void Start()
    {
        LevelUnlocker();   

    }

    

    public void LevelUnlocker()
    {
        int levelAt = PlayerPrefs.GetInt("levelAt", 2);

        for (int i = 0; i < buttons.Length; i++)
        {
            if (i + 2 > levelAt)
            {
                buttons[i].interactable = false;
                
            }
        }
    }

    public void DeleteSave()
    {
        PlayerPrefs.DeleteKey("levelAt");
    }


}
