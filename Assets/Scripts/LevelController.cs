using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public int nextSceneLoaded;

    private void Start()
    {
        nextSceneLoaded = SceneManager.GetActiveScene().buildIndex + 1;
    }

    public void Pass()
    {

        SceneManager.LoadScene(nextSceneLoaded);
        if (nextSceneLoaded > PlayerPrefs.GetInt("levelAt"))
        {
            PlayerPrefs.SetInt("levelAt", nextSceneLoaded);
        }

    }
}
