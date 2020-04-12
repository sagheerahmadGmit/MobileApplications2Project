using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void playGame()
    {
        FindObjectOfType<AudioManager>().Play("Click");
        SceneManager.LoadScene("Game");
    }

    public void quitGame()
    {
        FindObjectOfType<AudioManager>().Play("Click");
        Application.Quit();
    }
}
