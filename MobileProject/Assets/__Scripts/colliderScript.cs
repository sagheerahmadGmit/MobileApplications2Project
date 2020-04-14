using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colliderScript : MonoBehaviour
{
    public int counter;
    GameObject meteor;
    GameObject meteor1;
    GameObject meteor2;
    GameObject meteor3;

    private void Start()
    {
        meteor = GameObject.Find("Asteroid");
        meteor1 = GameObject.Find("Asteroid (1)");
        meteor2 = GameObject.Find("Asteroid (2)");
        meteor3 = GameObject.Find("Asteroid (3)");
    }

    private void Update()
    {
        counter = DamageHandler.playerDied;
        
        if (counter == 10)
        {
            Destroy(meteor);
            Destroy(meteor1);
            Destroy(meteor2);
            Destroy(meteor3);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {       
        var asteroid = collision.collider.GetComponent<EnemySpawner>();
        if (asteroid)
        {
            Destroy(asteroid.gameObject);
        }
        print(collision);
    }
}
