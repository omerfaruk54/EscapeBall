using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    [SerializeField] private LevelController levelController;
    public void OpenScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Level1");
    }

    public void Levels()
    {
        SceneManager.LoadScene("Levels");
    }

    public void BackButton()
    {
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }



}
