using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Virus : Enemy
{
    private Enemy virus;
    private EnemyHealth healthBar;

    private float _maxHealth = 50f;
    private float _currentHealth;
    private float _moveSpeed = 2f;
    private int _deathCoinReward = 10;
    private bool _isHidden = false;

    private void Start()
    {
        virus = GetComponent<Enemy>();
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
