using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUo : MonoBehaviour
{

    public GameObject effect;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Pickup();
        }
    }

    void Pickup()
    {
        //Spawn a effect
        Instantiate(effect, transform.position, transform.rotation);

        //Apply the effect to the player

        //Remove power up from the screen
        Destroy(gameObject);
    }
}
