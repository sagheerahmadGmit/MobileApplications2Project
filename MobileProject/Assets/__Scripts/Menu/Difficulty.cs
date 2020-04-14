using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Difficulty : MonoBehaviour
{

    public static int level;

    public void playGameEasy()
    {
        FindObjectOfType<AudioManager>().Play("Click");
        Score.scoreValue = 0;
        PlayerSpawner.numLives = 4;
        DamageHandler.playerDied = 0;
        level = 1;
        SceneManager.LoadScene("Game");
    }

    public void playGameMedium()
    {
        FindObjectOfType<AudioManager>().Play("Click");
        Score.scoreValue = 0;
        PlayerSpawner.numLives = 4;
        DamageHandler.playerDied = 0;
        level = 2;
        SceneManager.LoadScene("Game");
    }

    public void playGameHard()
    {
        FindObjectOfType<AudioManager>().Play("Click");
        Score.scoreValue = 0;
        PlayerSpawner.numLives = 4;
        DamageHandler.playerDied = 0;
        level = 3;
        SceneManager.LoadScene("Game");
    }
}
