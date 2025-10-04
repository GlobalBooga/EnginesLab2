using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemies;
    public Transform[] spawnPoints;
    public float spawnInterval = 3f;
    private float lastSpawn;
    

    private void Update()
    {
        if ((lastSpawn += Time.deltaTime) >= spawnInterval)
        {
            lastSpawn -= spawnInterval;
            
            // spawn
            int maxEnemies =  enemies.Length;
            int maxSpawns = spawnPoints.Length;
            Instantiate(enemies[Random.Range(0, maxEnemies)], spawnPoints[Random.Range(0, maxSpawns)].position, Quaternion.identity);
        }
    }
}
