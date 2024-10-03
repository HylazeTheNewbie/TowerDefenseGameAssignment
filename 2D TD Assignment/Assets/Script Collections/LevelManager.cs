using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [Header("Level Configurations")]
    public int maxWave;
    public int currentWave;
    public int currentMoney;
    public int lives;

    [Header("References")]
    private EnemySpawner enemySpawner;
    public static LevelManager main;

    private void Awake()
    {
        if (main == null)
        {
            main = this;
        }
        
        enemySpawner = GetComponent<EnemySpawner>();
    }

    public void IncreaseCurrency(int amount) {
        currentMoney += amount;
    }

    public bool SpendCurrency(int amount)
    {
        if (amount <= currentMoney)
        {
            currentMoney -= amount;
            return true;
        }
        else
        {
            Debug.Log("Insufficient money!");
            return false;
        }
    }
       
    private bool isMaxWaveDefeated()
    {
        if (currentWave >= maxWave && enemySpawner.enemiesAlive == 0 
            && enemySpawner.enemiesLeftToSpawn == 0)       
            return true;
        else
            return false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        StartCoroutine(VictoryOrLoseSceneLoaders());
    }

    private IEnumerator VictoryOrLoseSceneLoaders()
    {
        if (isMaxWaveDefeated())
        {
            yield return new WaitForSeconds(3);
            enemySpawner.isSpawning = false;
            SceneManager.LoadScene("WinGameScreen");
        }
        else if (lives <= 0)
        {
            yield return new WaitForSeconds(3);
            enemySpawner.isSpawning = false;
            SceneManager.LoadScene("GameOver");
        }
    }
}
