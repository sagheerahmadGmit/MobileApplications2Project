using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Difficulty : MonoBehaviour
{
    //get the difficulty level
    public static int level;

    //easy mode
    public void playGameEasy()
    {
        //play sound
        FindObjectOfType<AudioManager>().Play("Click");
        //reset the score and player lives
        Score.scoreValue = 0;
        PlayerSpawner.numLives = 4;
        //reset enemy damage
        DamageHandler.playerDied = 0;
        //set difficulty level
        level = 1;
        //change scene
        SceneManager.LoadScene("Game");
    }

    public void playGameMedium()
    {
        //play sound
        FindObjectOfType<AudioManager>().Play("Click");
        //reset the score and player lives
        Score.scoreValue = 0;
        PlayerSpawner.numLives = 4;
        //reset enemy damage
        DamageHandler.playerDied = 0;
        //set difficulty level
        level = 2;
        //change scene
        SceneManager.LoadScene("Game");
    }

    public void playGameHard()
    {
       //play sound
        FindObjectOfType<AudioManager>().Play("Click");
        //reset the score and player lives
        Score.scoreValue = 0;
        PlayerSpawner.numLives = 4;
        //reset enemy damage
        DamageHandler.playerDied = 0;
        //set difficulty level
        level = 3;
        //change scene
        SceneManager.LoadScene("Game");
    }
}
