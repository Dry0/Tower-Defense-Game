using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
   

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("SpawnEnemy");
    }

    IEnumerator SpawnEnemy() 
    {
        while(true) 
        { // dit zorgt ervoor dat de code elke 1 seconde wordt uitgevoerd
            yield return new WaitForSeconds(1);
            Instantiate(enemyPrefab);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
