using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField] List<EnemyWave> waves = new List<EnemyWave>();
    [SerializeField] Path path;
    [SerializeField] Transform container;

    float currentCooldown = 0;

    int waveCount = 0;
    EnemyWave currentEnemyWave;

    int enemyCount = 0;
    GameObject currentEnemy;
    bool Active = true;

    // Start is called before the first frame update
    void Start()
    {
        currentEnemyWave = waves[waveCount]; // currentEnemyWave is the amount of waves that are in the waveCount
        StartCoroutine(WaveLoop()); //start the loop 

    }

    IEnumerator WaveLoop() 
    {
        while (Active) 
        {


            yield return new WaitForSeconds(currentCooldown);
            GameObject gameObject1 = currentEnemyWave.enemies[enemyCount]; // added dont think this is the right one
            currentEnemy = gameObject1; // goes down the list of the way to spawn the enemies 
            //currentEnemy = currentEnemyWave.enemies[enemyCount]; // goes down the list of the way to spawn the enemies ORGINAL ONE
            enemyCount++;

            WayPointFollower follower = currentEnemy.GetComponent<WayPointFollower>(); // picks the follower and sets the path of follower to their path
            follower.path = path;

            Instantiate(currentEnemy, path.waypoints[0].position, Quaternion.Euler(Vector2.zero), container); // spawns the enemy to their path and makes the rotation zero
            if (enemyCount >= currentEnemyWave.enemies.Count) // checks if the current enemyCount is bigger or equal to the enmies in the current waves enemy lists count
            {
                waveCount ++; 
            }
            // to do
            // make a container for the enemies in unity with a emtpy transform V
            // make the wave either wait for the next wave or that you need to click on a button to proceed to the next wave
        }
    }
}
