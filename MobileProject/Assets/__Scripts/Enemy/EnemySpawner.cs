using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class EnemySpawner : MonoBehaviour {

	public GameObject enemyPrefab;

    //How far the enemies will spawn
	public float spawnDistance = 5f;

    //After how many seconds should the next enemy appear
	public float enemyRate = 5;

    //how many enemies should appear
	public float nextEnemy = 1;

    // Update is called once per frame
    void Update ()
    {
        nextEnemy -= Time.deltaTime;
        
        if (nextEnemy <= 0)
        {

            nextEnemy = enemyRate;

            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Level2"))
            {
                //make the enemies spawn faster and faster by 10%
                enemyRate *= 0.9f;
                if (enemyRate < 2)
                    enemyRate = 2;
            }

            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Level3"))
            {
                //make the enemies spawn faster and faster by 20%
                enemyRate *= 0.8f;
                if (enemyRate < 2)
                    enemyRate = 2;
            }

            SpawnEnemy();
        }
    }

    //Spawn the enemy
    void SpawnEnemy()
    {
        //make a random vector
        Vector3 offset = Random.onUnitSphere;
        offset.z = 0;
        //get the random sphere - x and y axis get normalized to one
        offset = offset.normalized * spawnDistance;
        //spawn the enemy
        Instantiate(enemyPrefab, transform.position + offset, Quaternion.identity);
    }
}
