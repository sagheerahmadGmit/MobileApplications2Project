using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DamageHandler : MonoBehaviour
{
    //enemy health
    public int health = 1;

    //save the current score and highscore
    public static int newScore;
    public static int highScore = 0;

    //how many times the enemy died
    public static int playerDied = 0;

    //gameobject for particle system
    public GameObject explosion;

    //on collision
    void OnTriggerEnter2D()
    {
        //decrease enemy health
        health--;
    }

    void Update()
    {
        //if the health is 0
        if (health <= 0)
        {
            //Player has no more lives
            Die();
        }
    }

    void Die()
    {
        //kill the enemy and instatiate the particle system while also playing deathSound
        FindObjectOfType<AudioManager>().Play("PlayerDeath");
        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
        
        //increase the score and save it
        Score.scoreValue += 10/2;
        newScore = Score.scoreValue;

        //get the level difficulty
        int level = Difficulty.level;

        if (level == 1)
        {
            //if the player reaches 50 they win
            if (newScore == 50)
            {
                playerDied = 0;
                PlayerSpawner.numLives += 1;
                SceneManager.LoadScene("GameOver");
            }
        }
        else if (level == 2)
        {
            //if the player reaches 50 go to level 2
            if (newScore == 50)
            {
                playerDied = 0;
                PlayerSpawner.numLives += 1;
                SceneManager.LoadScene("Level2");
            }

            //if the player reaches 100 they win
            if (newScore == 100)
            {
                playerDied = 0;
                PlayerSpawner.numLives += 1;
                SceneManager.LoadScene("GameOver");
            }
        }
        else {
            //if the player reaches 50 go to level 2
            if (newScore == 50)
            {
                playerDied = 0;
                PlayerSpawner.numLives += 1;
                SceneManager.LoadScene("Level2");
            }
            //if the player reaches 100 go to level 3
            if (newScore == 100)
            {
                playerDied = 0;
                PlayerSpawner.numLives += 1;
                SceneManager.LoadScene("Level3");

            }
            //if the player reaches 150 - they win
            if (newScore == 150)
            {
                playerDied = 0;
                SceneManager.LoadScene("GameOver");
            }
        }
        
        //set the new highscore
        if (highScore < newScore)
        {
            highScore = newScore;
        }

        Debug.Log("Player Died");
        //increase the counter for enemies dead
        playerDied++;
    }
}
