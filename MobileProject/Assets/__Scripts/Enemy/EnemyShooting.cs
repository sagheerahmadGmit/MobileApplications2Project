using UnityEngine;
using System.Collections;

public class EnemyShooting : MonoBehaviour
{
    //get the bullet offset
	public Vector3 bulletOffset = new Vector3(0, 0.5f, 0);

	//get the bullet prefab and bullet layer
	public GameObject bulletPrefab;
	int bulletLayer;

    //delay the shooting for half a second
	public float fireDelay = 0.50f;
	float cooldownTimer = 0;

    //get the player transform
	Transform player;

	void Start() {
        //get the bullet layer
		bulletLayer = gameObject.layer;
	}

	// Update is called once per frame
	void Update () {

		if(player == null) {
			// Find the player's ship!
			GameObject go = GameObject.FindWithTag ("Player");
			
			if(go != null) {
				player = go.transform;
			}
		}

        cooldownTimer -= Time.deltaTime;
		//shoot if the player is close to the enemy and the player exists
		if( cooldownTimer <= 0 && player != null && Vector3.Distance(transform.position, player.position) < 4) {
			// SHOOT!
			//Debug.Log ("Enemy Pew!");
			cooldownTimer = fireDelay;
			//get the bullets offset
			Vector3 offset = transform.rotation * bulletOffset;
			//instantiate the bullet
			GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, transform.position + offset, transform.rotation);
            //change the bullets layer to enemy layer
			bulletGO.layer = bulletLayer;
		}
	}
}
