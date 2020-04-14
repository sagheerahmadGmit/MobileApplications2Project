using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DamageHandler : MonoBehaviour
{
    public int health = 1;

    public static int newScore;
    public static int highScore = 0;
    public static int playerDied = 0;

    void OnTriggerEnter2D()
    {
        health--;
    }

    void Update()
    {
        if (health <= 0)
        {
            //Player has no more lives
            Die();
        }
    }

    void Die()
    {
        FindObjectOfType<AudioManager>().Play("PlayerDeath");
        Destroy(gameObject);
        Score.scoreValue += 10/2;
        newScore = Score.scoreValue;

        if (newScore == 50)
        {
            SceneManager.LoadScene("Level2");
            playerDied = 0;
        }

        if (newScore == 100)
        {
            SceneManager.LoadScene("Level3");
            playerDied = 0;
        }

        if (newScore == 150)
        {
            SceneManager.LoadScene("GameOver");
        }

        if (highScore < newScore)
        {
            highScore = newScore;
        }

        Debug.Log("Player Died");

        playerDied++;
    }
}
