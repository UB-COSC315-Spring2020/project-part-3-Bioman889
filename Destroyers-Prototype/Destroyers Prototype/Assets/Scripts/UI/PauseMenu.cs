using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;

     void Start()
    {
        //ensures the menu is turned off
        pauseMenuUI.SetActive(false);
    }

    void Update()
    {
        //allows the player to his escape to both pause and unpause the game
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameIsPaused)
            {
                Resume();
            }else
            {
                Pause();
            }
        }
    }
    public void Resume()
    {
        //resumes the game and hides the pause UI
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    void Pause()
    {
        //pauses the game and raises the pause UI
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Start Menu");
    }
    
}
