using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamage : MonoBehaviour
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
        Destroy(gameObject);
    }
}
