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

	void SpawnPlayer() {
        numLives--;
        respawnTimer = 1;
		playerInstance = (GameObject)Instantiate(playerPrefab, transform.position, Quaternion.identity);
        StartCoroutine("GetInvulnerable");
    }
	
	// Update is called once per frame
	void Update () {
		if(playerInstance == null && numLives > 0) {
			respawnTimer -= Time.deltaTime;

			if(respawnTimer <= 0) {
				SpawnPlayer();
			}
		}
	}

	void OnGUI() {
		if(numLives >= 0 || playerInstance!= null) {
			GUI.Label( new Rect(0, 0, 100, 50), "Lives Left: " + numLives);
		}
		
        if (numLives <= 0)
        {
            FindObjectOfType<AudioManager>().Play("PlayerDeath");
            SceneManager.LoadScene("GameLost");
        }
	}

    IEnumerator GetInvulnerable()
    {
        Physics2D.IgnoreLayerCollision(8, 9, true);
        yield return new WaitForSeconds(3f);
        Physics2D.IgnoreLayerCollision(8, 9, false);
    }
}
