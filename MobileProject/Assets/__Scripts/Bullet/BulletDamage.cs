using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamage : MonoBehaviour
{
    //give the bullet a health of one
    public int health = 1;
    
    void OnTriggerEnter2D()
    {
        //decrease health when it collides with anything
        health--;
    }

    void Update()
    {
        //if health is 0 destroy the bullet
        if (health <= 0)
        {
            //Player has no more lives
            Die();
        }
    }

    //destroy the bullet
    void Die()
    {
        //destroy Bullet
        Destroy(gameObject);
    }
}
