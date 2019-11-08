using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject enemy;
    public float spawnTime = 5f;
    public float spawnDelay = 3f; 

// Use this for initialization
    void Start () {
        InvokeRepeating (nameof(SpawnEnemy), spawnDelay, spawnTime);
        // Invoked method, every spawnDelay, at repeated rate of spawnTime

    }

    void SpawnEnemy() {
        var spawnPointIndex = Random.Range(0, spawnPoints.Length);
        Instantiate (enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
    }

}