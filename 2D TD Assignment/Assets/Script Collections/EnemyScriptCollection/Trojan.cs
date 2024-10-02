using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        waypointList = EnemyPathing.main.path1;

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
