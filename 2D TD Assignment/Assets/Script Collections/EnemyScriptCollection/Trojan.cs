using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Trojan : Enemy
{
    private Enemy trojan;
    private EnemyHealth healthBar;

    private float _maxHealth = 75f;
    private float _currentHealth;
    private float _moveSpeed = 2.5f;
    private int _deathCoinReward = 25;
    private bool _isHidden = true;

    private void Start()
    {
        trojan = GetComponent<Enemy>();
        healthBar = GetComponentInChildren<EnemyHealth>();

        InitializeAttributes(_maxHealth, _moveSpeed, _deathCoinReward, _isHidden, healthBar);
        _currentHealth = _maxHealth;

        SetEnemyMaxHealth(_maxHealth);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ReceiveDamage(20);
        }
    }
}
