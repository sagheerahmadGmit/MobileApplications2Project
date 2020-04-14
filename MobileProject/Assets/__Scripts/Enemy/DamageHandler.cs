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
    public GameObject explosion;

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
        Instantiate(explosion, transform.position, Quaternion.identity);

        Score.scoreValue += 10/2;
        newScore = Score.scoreValue;

        int level = Difficulty.level;

        if (level == 1)
        {
            if (newScore == 50)
            {
                playerDied = 0;
                PlayerSpawner.numLives += 1;
                SceneManager.LoadScene("GameOver");
            }
        }
        else if (level == 2)
        {
            if (newScore == 50)
            {
                playerDied = 0;
                PlayerSpawner.numLives += 1;
                SceneManager.LoadScene("Level2");
            }

            if (newScore == 100)
            {
                playerDied = 0;
                PlayerSpawner.numLives += 1;
                SceneManager.LoadScene("GameOver");
            }
        }
        else {
            if (newScore == 50)
            {
                playerDied = 0;
                PlayerSpawner.numLives += 1;
                SceneManager.LoadScene("Level2");
            }

            if (newScore == 100)
            {
                playerDied = 0;
                PlayerSpawner.numLives += 1;
                SceneManager.LoadScene("Level3");

            }

            if (newScore == 150)
            {
                playerDied = 0;
                SceneManager.LoadScene("GameOver");
            }
        }
        
        if (highScore < newScore)
        {
            highScore = newScore;
        }

        Debug.Log("Player Died");

        playerDied++;
    }
}
