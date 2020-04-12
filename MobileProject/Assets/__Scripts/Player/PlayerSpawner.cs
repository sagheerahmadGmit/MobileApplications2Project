using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerSpawner : MonoBehaviour {

	public GameObject playerPrefab;
	GameObject playerInstance;

	public int numLives = 4;
	float respawnTimer;

	// Use this for initialization
	void Start () {
		SpawnPlayer();
	}

	void SpawnPlayer() {
        //FindObjectOfType<AudioManager>().Play("PlayerRespawn");
        numLives--;
        DamageHandler.invulnPeriod = 5f;
        respawnTimer = 1;
		playerInstance = (GameObject)Instantiate(playerPrefab, transform.position, Quaternion.identity);
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
            Score.scoreValue = 0;
            FindObjectOfType<AudioManager>().Play("PlayerDeath");
            SceneManager.LoadScene("EndPage");
        }
	}
}
