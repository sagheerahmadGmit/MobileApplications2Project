using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    //add a particle system
    public GameObject effect;
    //get lives of player
    public int lives;

    void Update()
    {
        //get player lives
        lives = PlayerSpawner.numLives;

        //show the heart if the player has 1 life
        if (lives == 1)
        {
            //show the health power up
            gameObject.SetActive(true);
        }
        else
        {
            //else hide the health power up
            gameObject.SetActive(false);
        }
    }

    //on collision with player
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //pick up the health
            Pickup(collision);
        }
    }

    //pick up the heart
    void Pickup(Collider2D player)
    {
        //Spawn a effect
        Instantiate(effect, transform.position, transform.rotation);

        //Apply the effect to the player
        PlayerSpawner.numLives = 4;

        //Remove power up from the screen
        Destroy(gameObject);
    }
}
