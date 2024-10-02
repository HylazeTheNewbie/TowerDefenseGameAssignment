using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public EnemySpawner enemySpawner;
    private int MaxWave { get; set; }

    public int CurrentWave{ get; set;}
    public int TotalLives { get; set; }
    public int CurrentLives { get; set; }

    public float timeBetweenWaves = 5f;

    public int currency;

    private void Start()
    {
        currency = 100;
    }

    public void increaseCurrency(int amount)
    {
        currency += amount;
    }

    public bool SpendCurrency(int amount)
    {
        if(amount <= currency)
        {
            currency -= amount;
            return true;
        }
        else
        {
            Debug.Log("You dont have enough money to buy this tower");
            return false;
        }
    }


    private void Start()
    {
        TotalLives = 15;
        CurrentWave = 0;
    }

    private void ReduceLives(Enemy enemy)
    {
        TotalLives--;
        EnemySpawner.onEnemySlain.Invoke();    

        if (TotalLives <= 0)
        {
            TotalLives = 0;
            GameOver();
        }
    }

    private void GameOver()
    {

    }

    private void OnEnable()
    {
        ActionSets.OnEnemyReached += ReduceLives;
    }

    private void OnDisable()
    {
        ActionSets.OnEnemyReached -= ReduceLives;
    }
}