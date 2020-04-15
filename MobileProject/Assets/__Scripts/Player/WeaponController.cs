using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    //get the bullet offset
    public Vector3 bulletOffset = new Vector3(0, 0.5f, 0);

    //get the bullet prefab and layer
    public GameObject bulletPrefab;
    int bulletLayer;

    //delay in between shooting
    public float fireDelay = 0.25f;
    float cooldownTimer = 0;
    
    // Update is called once per frame
    void Update()
    {
        cooldownTimer -= Time.deltaTime;
        //get the fire button to shoot
        if (Input.GetButton("Fire1") && cooldownTimer <= 0)
        {
            // SHOOT!
            cooldownTimer = fireDelay;
            //get the player bullet offset
            Vector3 offset = transform.rotation * bulletOffset;
            //instantiate the bullet
            Instantiate(bulletPrefab, transform.position + offset, transform.rotation);
        }
    }
}
