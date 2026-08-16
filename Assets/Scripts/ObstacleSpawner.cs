using UnityEngine;
using System.Collections.Generic;

public class ObstacleSpawner : MonoBehaviour
{
    public Transform[] spawnPoints; // x positions per lane
    public List<GameObject> obstaclePrefabs;
    public float spawnInterval = 1.2f;
    float timer = 0f;
    float gameSpeedMultiplier = 1f;

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            SpawnObstacle();
            timer = spawnInterval / gameSpeedMultiplier;
        }

        // increase difficulty over time
        gameSpeedMultiplier = 1f + (Time.timeSinceLevelLoad / 60f);
    }

    void SpawnObstacle()
    {
        if (spawnPoints == null || spawnPoints.Length == 0 || obstaclePrefabs == null || obstaclePrefabs.Count == 0) return;
        int lane = Random.Range(0, spawnPoints.Length);
        var prefab = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Count)];
        Instantiate(prefab, spawnPoints[lane].position, Quaternion.identity);
    }
}
