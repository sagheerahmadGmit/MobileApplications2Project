using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //when the player chooses play, the play the game
    public void playGame()
    {
        //play clicking sound
        FindObjectOfType<AudioManager>().Play("Click");
        //reset the score and player lives
        Score.scoreValue = 0;
        PlayerSpawner.numLives = 4;
        //reset enemy damage
        DamageHandler.playerDied = 0;
        //change scene
        SceneManager.LoadScene("Game");
    }

    //quit the game
    public void quitGame()
    {
        //play sound from audio manager
        FindObjectOfType<AudioManager>().Play("Click");
        //quit
        Application.Quit();
    }
}
