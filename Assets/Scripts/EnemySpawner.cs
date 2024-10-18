using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnRate = 2f;
    public float spawnRangeX = 8f;
    private float timeSinceLastSpawn = 0f;
    public float difficultyIncreaseRate = 0.5f; // Increase difficulty over time

    private void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;

        if (timeSinceLastSpawn >= spawnRate)
        {
            SpawnEnemy();
            timeSinceLastSpawn = 0f;
            spawnRate = Mathf.Max(0.5f, spawnRate - difficultyIncreaseRate * Time.deltaTime);
        }
    }

    private void SpawnEnemy()
    {
        float randomX = Random.Range(-spawnRangeX, spawnRangeX);
        Vector3 spawnPosition = new Vector3(randomX, 6f, 0);
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }
}
