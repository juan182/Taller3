using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; 
    public float spawnInterval = 5f; 
    public GameObject[] spawnPoints; 

    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        while (true)
        {
            int enemyCount = Random.Range(3, 6); // Genera entre 3 y 5 enemigos
            for (int i = 0; i < enemyCount; i++)
            {
                if (spawnPoints.Length > 0)
                {
                    int randomIndex = Random.Range(0, spawnPoints.Length);
                    Vector3 spawnPosition = spawnPoints[randomIndex].transform.position;
                    Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
                }
            }
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
