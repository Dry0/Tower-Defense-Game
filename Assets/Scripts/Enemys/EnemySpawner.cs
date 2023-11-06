using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    //[SerializeField] private float spawnInterval = 1;  

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("SpawnEnemy");
    }

    IEnumerator SpawnEnemy() 
    {
        while(true) 
        { // dit zorgt ervoor dat de code elke 1 seconde wordt uitgevoerd
            Instantiate(enemyPrefab);
            yield return new WaitForSeconds(1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
