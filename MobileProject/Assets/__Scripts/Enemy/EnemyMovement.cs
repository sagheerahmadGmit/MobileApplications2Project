using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    //rotation speed
    public float rotSpeed = 90f;
    //get the player to follow
    Transform player;

    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            // Find the player's ship!
            GameObject go = GameObject.FindWithTag("Player");

            //if the playership exists
            if (go != null)
            {
                //save the player transform
                player = go.transform;
            }
        }

        // At this point, we've either found the player,
        // or it doesn't exist right now.
        //try and find it again next frame
        if (player == null)
            return;

        //we know for sure we have a player. Turn to face it
        //get the player position and normalize it
        Vector3 dir = player.position - transform.position;
        dir.Normalize();

        float zAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;
        //rotate the enemy ship 
        Quaternion desiredRot = Quaternion.Euler(0, 0, zAngle);
        //rotate towards the player
        transform.rotation = Quaternion.RotateTowards(transform.rotation, desiredRot, rotSpeed * Time.deltaTime);
    }
}
