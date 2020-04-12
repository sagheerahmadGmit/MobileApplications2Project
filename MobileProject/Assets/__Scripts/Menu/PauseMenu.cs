using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenu : MonoBehaviour
{

    public static bool gameIsPaused = false;

    public GameObject pauseMenuUI;
        
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
            {
                Resume();
            }
            else {
                Pause();
            }
        }
    }

    public void Pause()
    {
        FindObjectOfType<AudioManager>().Play("Click");
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    public void Resume()
    {
        FindObjectOfType<AudioManager>().Play("Click");
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;

    }

    public void LoadMenu()
    {
        FindObjectOfType<AudioManager>().Play("Click");
        Debug.Log("Loading Menu");
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame()
    {
        FindObjectOfType<AudioManager>().Play("Click");
        Debug.Log("Quitting Menu");
        Application.Quit();
    }

}


