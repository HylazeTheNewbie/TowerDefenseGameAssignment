using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private int enemyCount = 8;
    [SerializeField] private GameObject enemyGO;

    [Header("Fixed Delay")]
    [SerializeField] private float delayBtwSpawns;

    private float spawnTimer;
    private int enemiesSpawned;

    private ObjectPooler pooler;
    // Start is called before the first frame update
    void Start()
    {
        pooler = GetComponent<ObjectPooler>();
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer -= Time.deltaTime;

        if (spawnTimer < 0)
        {
            spawnTimer = delayBtwSpawns;
            if (enemiesSpawned < enemyCount)
            {
                enemiesSpawned++;
                SpawnEnemy();
            }
        }
    }

    private void SpawnEnemy()
    {
        GameObject newInstance = pooler.GetInstanceFromPool();
        newInstance.SetActive(false);
    }
}
