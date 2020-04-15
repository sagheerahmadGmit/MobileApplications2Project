using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        //destroy the particle system after 2 secs
        Destroy(gameObject, 2f);
    }
}
