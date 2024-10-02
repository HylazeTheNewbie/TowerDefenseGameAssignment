using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using Unity.VisualScripting;

public class EnemySpawner : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private int EnemyEquilvalent = 6;
    [SerializeField] private float difficultyScaleFactor = 0.4f;
    [SerializeField] private float enemiesPerSecond = 0.75f;
    [SerializeField] private bool isSpawning = false;
    [SerializeField] private float timeSinceLastSpawn;
    [SerializeField] private int enemiesAlive;
    [SerializeField] private int enemiesLeftToSpawn;

    public GameObject[] enemyTypes;
    public Transform spawnPoint;

    [Header("Fixed Delay")]
    [SerializeField] private float delayBtwSpawns = 5;

    public LevelManager LM;
    public static UnityEvent onEnemySlain = new UnityEvent();

    void Awake()
    {
        onEnemySlain.AddListener(EnemyDestroy);
        LM = GameObject.FindObjectOfType<LevelManager>();
    }

    private void Start()
    {
        StartCoroutine(StartWave());
    }

    void Update()
    {
        StartSpawnEnemy();
    }

    private void EnemyDestroy()
    {
        enemiesAlive--;
    }

    private int EnemyEquilvalentPerWave()
    {
        return Mathf.RoundToInt(EnemyEquilvalent * Mathf.Pow(LM.CurrentWave, difficultyScaleFactor));
    }

    private void SpawnEnemy()
    {
        GameObject enemyPrefab = GetEnemyTypeForWave(LM.CurrentWave);
        ObjectPoolManager.SpawnObject(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }

    private GameObject GetEnemyTypeForWave(int level)
    {
        Debug.Log(level);
        return enemyTypes[(level - 1) % enemyTypes.Length];
    }

    private IEnumerator StartWave()
    {
        yield return new WaitForSeconds(delayBtwSpawns);
        isSpawning = true;
        enemiesLeftToSpawn = EnemyEquilvalentPerWave();
        LM.CurrentWave++;
    }

    private void StartSpawnEnemy()
    {
        if (!isSpawning) return;

        timeSinceLastSpawn += Time.deltaTime;

        if (timeSinceLastSpawn >= (1f / enemiesPerSecond) && enemiesLeftToSpawn > 0)
        {
            SpawnEnemy();
            enemiesAlive++;
            enemiesLeftToSpawn--;
            timeSinceLastSpawn = 0f;
        }

        if (enemiesAlive == 0 && enemiesLeftToSpawn == 0)
            EndWave();
    }

    private void EndWave()
    {
        isSpawning = false;
        timeSinceLastSpawn = 0f;
        StartCoroutine(StartWave());
    }
}
