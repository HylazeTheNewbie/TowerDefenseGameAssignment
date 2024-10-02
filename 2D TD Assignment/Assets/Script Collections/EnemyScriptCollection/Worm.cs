using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worm : Enemy
{
    private Enemy worm;
    private EnemyHealth healthBar;

    private float _maxHealth = 100f;
    private float _currentHealth;
    private float _moveSpeed = 1.5f;
    private int _deathCoinReward = 15;
    private bool _isHidden = false;

    private void Start()
    {
        worm = GetComponent<Enemy>();
        healthBar = GetComponentInChildren<EnemyHealth>();

        InitializeAttributes(_maxHealth, _moveSpeed, _deathCoinReward, _isHidden, healthBar);
        _currentHealth = _maxHealth;

        waypointList = EnemyPathing.main.path2;
        SetEnemyMaxHealth(_maxHealth);
    }

    private void Update()
    {
        Move();
        Rotate();

        if (CurrentPointPositionReached())
        {
            UpdateCurrentPointIndex();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            ReceiveDamage(20);
        }
    }
}