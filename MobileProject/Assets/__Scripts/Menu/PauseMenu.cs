using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenu : MonoBehaviour
{
    //pause menu set to false - not paused
    public static bool gameIsPaused = false;
    //get the menu object
    public GameObject pauseMenuUI;
        
    // Update is called once per frame
    void Update()
    {
        //when esc is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //if the game is already paused then resume the game else pause the game and show menu
            if (gameIsPaused)
            {
                Resume();
            }
            else {
                Pause();
            }
        }
    }

    //pause the game
    public void Pause()
    {
        //play sound
        FindObjectOfType<AudioManager>().Play("Click");
        //show the menu
        pauseMenuUI.SetActive(true);
        //freeze time
        Time.timeScale = 0f;
        //set game paused to true - paused
        gameIsPaused = true;
    }

    public void Resume()
    {
        //play sound
        FindObjectOfType<AudioManager>().Play("Click");
        //hide the menu
        pauseMenuUI.SetActive(false);
        //unfreeze time
        Time.timeScale = 1f;
        //set game paused to false - not paused
        gameIsPaused = false;

    }
    
    //load the menu
    public void LoadMenu()
    {
        //play sound
        FindObjectOfType<AudioManager>().Play("Click");
        Debug.Log("Loading Menu");
        //unfreeze the time
        Time.timeScale = 1f;
        //change scenes
        SceneManager.LoadScene("Menu");
    }

    //quit game
    public void QuitGame()
    {
        //play sound
        FindObjectOfType<AudioManager>().Play("Click");
        Debug.Log("Quitting Menu");
        //quit the game
        Application.Quit();
    }

}


