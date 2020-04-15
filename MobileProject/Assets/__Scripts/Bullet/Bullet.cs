using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float maxSpeed = 5f;
    
    void Update()
    {
        //get the postion of the transform
        Vector3 pos = transform.position;

        //get the velocity - change in the position
        Vector3 velocity = new Vector3(0, maxSpeed * Time.deltaTime, 0);

        //move the bullet
        pos += transform.rotation * velocity;
        transform.position = pos;
    }
}
