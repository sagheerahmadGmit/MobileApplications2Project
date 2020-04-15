using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colliderScript : MonoBehaviour
{
    //get the game objects
    public int counter;
    GameObject meteor;
    GameObject meteor1;
    GameObject meteor2;
    GameObject meteor3;

    private void Start()
    {
        //find the gameobjects and save them into the variables
        meteor = GameObject.Find("Asteroid");
        meteor1 = GameObject.Find("Asteroid (1)");
        meteor2 = GameObject.Find("Asteroid (2)");
        meteor3 = GameObject.Find("Asteroid (3)");
    }

    private void Update()
    {
        //get the count of enemies and players colliding with the asteroids
        counter = DamageHandler.playerDied;
        
        //if the counter is over 10 destroy all asteroids
        //this is so the player cannot use the asteroids as cover
        if (counter == 10)
        {
            //destroy the asteroids
            Destroy(meteor);
            Destroy(meteor1);
            Destroy(meteor2);
            Destroy(meteor3);
        }
    }

    //get the collisions
    private void OnCollisionEnter2D(Collision2D collision)
    {       
        //save the component
        var asteroid = collision.collider.GetComponent<EnemySpawner>();
        if (asteroid)
        {
            //destroy anything that collides with the asteroid
            Destroy(asteroid.gameObject);
        }
        Debug.Log(collision);
    }
}
