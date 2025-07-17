using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnInterval = 2f;
    public float spawnZ = 20f; // Distância à frente do jogador onde os inimigos aparecem
    public float laneDistance = 2.5f;

    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void SpawnEnemy()
    {
        int lane = Random.Range(0, 3); // 0 = esquerda, 1 = meio, 2 = direita
        float xPos = (lane - 1) * laneDistance;

        Vector3 spawnPos = new Vector3(xPos, 0f, spawnZ);
        Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
    }
}