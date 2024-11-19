using CarterGames.Assets.AudioManager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Difficulty
{
    Tutorial,VeryEasy, Easy, Medium, Hard
}

public class SpawnEnemies : MonoBehaviour
{
    public GameObject enemyPrefab;  // Reference to the enemy prefab
    public Transform[] frontSideSpawnPoints;  // Array of spawn points on the front side
    public Transform[] leftSideSpawnPoints;   // Array of spawn points on the left side
    public Transform[] rightSideSpawnPoints;  // Array of spawn points on the right side
    public float spawnInterval = 7f;  // Interval to spawn enemies
    public Difficulty difficulty; // Public so you can change it in the Inspector
    private Coroutine spawnCoroutine;


    void Start()
    {
        // Start the coroutine to spawn enemies at regular intervals
        spawnCoroutine = StartCoroutine(SpawnEnemiesRoutine());
    }

    IEnumerator SpawnEnemiesRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);
            SpawnEnemiesBasedOnDifficulty();
        }
    }

    public void StopSpawning()
    {
        if (spawnCoroutine != null)
        {
            StopCoroutine(spawnCoroutine);
            spawnCoroutine = null;
        }
    }

    void SpawnEnemiesBasedOnDifficulty()
    {
        ClearExistingEnemies();

        switch (difficulty)
        {
            case Difficulty.Tutorial:
                SpawnEnemy(frontSideSpawnPoints[Random.Range(0, frontSideSpawnPoints.Length)].position);
                AudioManager.instance.Play("EnemySpawn");
                break;

            case Difficulty.VeryEasy:
                SpawnEnemy(frontSideSpawnPoints[Random.Range(0, frontSideSpawnPoints.Length)].position);
                SpawnEnemy(leftSideSpawnPoints[Random.Range(0, leftSideSpawnPoints.Length)].position);
                SpawnEnemy(rightSideSpawnPoints[Random.Range(0, rightSideSpawnPoints.Length)].position);
                AudioManager.instance.Play("EnemySpawn");
                break;

            case Difficulty.Easy:
                SpawnRandomEnemies(3);
                break;

            case Difficulty.Medium:
                SpawnRandomEnemies(5);
                break;
        }
    }

    void SpawnEnemy(Vector3 position)
    {
        Instantiate(enemyPrefab, position, Quaternion.identity);
        
    }

    public void SpawnRandomEnemies(int count)
    {
        for (int i = 0; i < count; i++)
        {
            Vector3 randomPosition = GetRandomSidePosition();
            SpawnEnemy(randomPosition);
            
        }
        AudioManager.instance.Play("EnemySpawn", volume: 0.5f);
    }

    Vector3 GetRandomSidePosition()
    {
        Transform[][] allSides = new Transform[][] { frontSideSpawnPoints, leftSideSpawnPoints, rightSideSpawnPoints };
        Transform[] selectedSide = allSides[Random.Range(0, allSides.Length)];
        Transform randomSpawnPoint = selectedSide[Random.Range(0, selectedSide.Length)];
        return randomSpawnPoint.position;
    }

    void ClearExistingEnemies()
    {
        foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            Destroy(enemy);
        }
    }
}
