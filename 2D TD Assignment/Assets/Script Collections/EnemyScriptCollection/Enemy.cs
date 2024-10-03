using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [Header("Common Attributes")]
    [SerializeField] public float maxHealth;
    [SerializeField] public float currentHealth;
    [SerializeField] public float moveSpeed;
    [SerializeField] public int deathCoinReward;
    [SerializeField] public bool isHidden;

    private EnemyHealth _healthBar;
    private Slider _healthSlider;

    public float MaxHealth => maxHealth;
    void Start()
    {
        _healthBar = GetComponent<EnemyHealth>();
        _healthSlider = _healthBar.healthSlider.GetComponent<Slider>();
        currentHealth = maxHealth;
        SetEnemyMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool ReturnIsHiddenEnemy()
    {
        return isHidden;
    }

    protected void InitializeAttributes(float maxHealth, float moveSpeed, int deathCoinReward, 
        bool isHidden, EnemyHealth _healthBar)
    {
        this.maxHealth = maxHealth;
        this.moveSpeed = moveSpeed;
        this.deathCoinReward = deathCoinReward;
        this.isHidden = isHidden;
        this._healthBar = _healthBar;
    }

    protected void SetEnemyMaxHealth(float maxHealth)
    {
        _healthBar.SetMaxHealth(maxHealth);
    }

    public void ReceiveDamage(float damageReceived)
    {
        _healthBar.DealDamage(damageReceived);
    }
}
