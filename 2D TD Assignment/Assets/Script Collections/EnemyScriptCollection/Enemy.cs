using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [Header("Common Attributes")]
    [SerializeField] protected float maxHealth;
    [SerializeField] protected float currentHealth;
    [SerializeField] protected float moveSpeed;
    [SerializeField] protected int deathCoinReward;
    [SerializeField] protected bool isHidden;

    private EnemyHealth _healthBar;
    private Slider _healthSlider;

    public float MaxHealth => maxHealth;
    void Start()
    {
        _healthBar = GetComponent<EnemyHealth>();
        _healthSlider = _healthBar.healthSlider.GetComponent<Slider>();
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

    protected void ReceiveDamage(float damageReceived)
    {
        _healthBar.DealDamage(damageReceived);
    }
}
