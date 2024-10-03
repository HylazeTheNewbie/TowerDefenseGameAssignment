using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public Slider healthSlider;
    private Enemy _enemy;

    [SerializeField] private int currencyWorth = 50;

    SoundManager audioManager; 

    // Start is called before the first frame update
    void Start()
    {
       healthSlider = GetComponentInChildren<Slider>();
       _enemy = GetComponent<Enemy>();
    }

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<SoundManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetMaxHealth(float health)
    {
        healthSlider.maxValue = health;
        healthSlider.value = health;
    }

    public void SetHealth(float currentHealth)
    {
        healthSlider.value = currentHealth;
    }

    public void DealDamage(float damageReceived)
    {
        float currentHealth = healthSlider.value;
        currentHealth -= damageReceived;
        healthSlider.value = currentHealth;

        if (currentHealth <= 0)
        {
            
            currentHealth = 0;
            Die();
        }
        else
        {
            ActionSets.OnEnemyHit?.Invoke(_enemy);
        }
    }

    public void Die()
    {
        audioManager.PlaySFX(audioManager.death);
        ActionSets.OnEnemyKilled?.Invoke(_enemy);
        EnemySpawner.onEnemyDestroyed.Invoke();
        Destroy(gameObject);
    }
}
