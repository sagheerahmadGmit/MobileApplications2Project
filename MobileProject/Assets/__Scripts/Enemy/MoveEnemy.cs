using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : MonoBehaviour
{
    //speed of the enemy
    public float maxSpeed = 3f;

    void Update()
    {
        //get the postion of the enemy
        Vector3 pos = transform.position;
        //get the velocity
        Vector3 velocity = new Vector3(0, maxSpeed * Time.deltaTime, 0);

        //move the enemy
        pos += transform.rotation * velocity;
        transform.position = pos;
    }
}
