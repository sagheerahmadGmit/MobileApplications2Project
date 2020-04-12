using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DamageHandler : MonoBehaviour
{
    public int health = 1;

    public static float invulnPeriod = 0;
    float invulnTimer = 0;
    int correctLayer;
    public static int newScore;
    public static int highScore = 0;

    SpriteRenderer spriteRend;

    void Start()
    {
        correctLayer = gameObject.layer;

        // This only get the renderer on the parent object.
        // In other words, it doesn't work for children. I.E. "enemy01"
        spriteRend = GetComponent<SpriteRenderer>();

        if (spriteRend == null)
        {
            spriteRend = transform.GetComponentInChildren<SpriteRenderer>();

            if (spriteRend == null)
            {
                Debug.LogError("Object '" + gameObject.name + "' has no sprite renderer.");
            }
        }
    }

    void OnTriggerEnter2D()
    {
        health--;
        //newScore =  Score.scoreValue += 10;
        //Score.scoreValue += 10;
        if (invulnPeriod > 0)
        {
            invulnTimer = invulnPeriod;
            gameObject.layer = 10;
        }
    }

    void Update()
    {

        if (invulnTimer > 0)
        {
            invulnTimer -= Time.deltaTime;

            if (invulnTimer <= 0)
            {
                gameObject.layer = correctLayer;
                if (spriteRend != null)
                {
                    spriteRend.enabled = true;
                }
            }
            else
            {
                if (spriteRend != null)
                {
                    spriteRend.enabled = !spriteRend.enabled;
                }
            }
        }

        if (health <= 0)
        {
            //Player has no more lives
            Die();
            //newScore = Score.scoreValue += 10;
            //Score.scoreValue += 10;
            //Score.scoreValue = 0;
            //SceneManager.LoadScene("EndPage");
        }
    }

    void Die()
    {
        FindObjectOfType<AudioManager>().Play("PlayerDeath");
        Destroy(gameObject);
        Score.scoreValue += 10/2;
        newScore = Score.scoreValue;

        if (highScore < newScore)
        {
            highScore = newScore;
        }

        Debug.Log("Player Died");
    }
}
