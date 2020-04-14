using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public GameObject effect;
    public int lives;

    void Update()
    {
        lives = PlayerSpawner.numLives;

        if (lives == 1)
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Pickup(collision);
        }
    }

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
