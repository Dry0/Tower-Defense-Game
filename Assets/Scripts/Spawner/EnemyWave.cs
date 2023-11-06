using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] // het wordt in plaats van een script een lijst van variabelen
public class EnemyWave 
{
   public List<GameObject> enemies = new List<GameObject>();
   public float spawnCooldown = 1f;
}
