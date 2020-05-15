using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        // loads the level
        SceneManager.LoadScene("LevelScene");
    }
    public void QuitGame()
    {
        // quits the game
        Application.Quit();
    }
}