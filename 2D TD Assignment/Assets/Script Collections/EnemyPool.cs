using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{

    public static EnemyPool enemyPool;

    [Header("References")]
    public GameObject enemyPrefab;

    [Header("Attributes")]
    public int initialPoolSize = 20;
    public int poolGrowthFactor = 10;  // How many enemies to add when pool runs out

    private List<GameObject> pooledEnemies = new List<GameObject>();

    private void Awake()
    {
        enemyPool = this;
    }

    private void Start()
    {
        // Pre-populate the pool with an initial number of enemies
        for (int i = 0; i < initialPoolSize; i++)
        {
            GameObject enemy = Instantiate(enemyPrefab);
            enemy.SetActive(false);
            pooledEnemies.Add(enemy);
        }
    }

    public GameObject GetPooledEnemy()
    {
        // Look for an inactive enemy in the pool
        foreach (var enemy in pooledEnemies)
        {
            if (!enemy.activeInHierarchy)
            {
                enemy.transform.position = LevelManager.main.startPoint.position;
                return enemy;
            }
        }

        // If no inactive enemy is found, expand the pool
        ExpandPool(poolGrowthFactor);

        // Return the newly added enemy
        return pooledEnemies[pooledEnemies.Count - poolGrowthFactor];
    }

    public void ReturnEnemyToPool(GameObject enemy)
    {
        enemy.SetActive(false);
    }

    private void ExpandPool(int additionalEnemies)
    {
        for (int i = 0; i < additionalEnemies; i++)
        {
            GameObject enemy = Instantiate(enemyPrefab);
            enemy.SetActive(false);
            pooledEnemies.Add(enemy);
        }

        Debug.Log($"{additionalEnemies} enemies added to the pool. New pool size: {pooledEnemies.Count}");
    }
}
