using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerSpawner : MonoBehaviour {

    //get the player prefab and instance
	public GameObject playerPrefab;
	GameObject playerInstance;

    //number of lives of player and respawn player
	public static int numLives = 4;
	float respawnTimer;
    
    // Use this for initialization
    void Start () {
        SpawnPlayer();
    }

    //spawn the player
	void SpawnPlayer() {
        //minus 1 life everytime
        numLives--;
        //reset the respawn timer
        respawnTimer = 1;
        //spawn the player
		playerInstance = (GameObject)Instantiate(playerPrefab, transform.position, Quaternion.identity);
        //start a coroutine
        StartCoroutine("GetInvulnerable");
    }
	
	// Update is called once per frame
	void Update () {
        //check if the player has more then 0 lives and decrease the respawn time
		if(playerInstance == null && numLives > 0) {
			respawnTimer -= Time.deltaTime;
            //respawn the player
			if(respawnTimer <= 0) {
				SpawnPlayer();
			}
		}
	}
    //Print out the lives of the player on the top left of the screen
	void OnGUI() {
        //How many lives are left
		if(numLives >= 0 || playerInstance!= null) {
			GUI.Label( new Rect(0, 0, 100, 50), "Lives Left: " + numLives);
		}
		
        //if the player has no more lives - Game over
        if (numLives <= 0)
        {
            //play game over sound
            FindObjectOfType<AudioManager>().Play("GameOver");
            //change the scene
            SceneManager.LoadScene("GameLost");                    
        }
	}

    //make the player Invulnerable
    IEnumerator GetInvulnerable()
    {
        //ignore all collisions between enemy and player
        Physics2D.IgnoreLayerCollision(8, 9, true);
        //wait for 3 seconds
        yield return new WaitForSeconds(3f);
        //allow all collisions again
        Physics2D.IgnoreLayerCollision(8, 9, false);
    }
}
