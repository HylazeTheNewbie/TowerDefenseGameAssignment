using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
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
    [HideInInspector] protected List<Transform> waypointList;

    protected SpriteRenderer _sr;
    protected EnemyPathing enemyPath;   
    private EnemyHealth _healthBar;
    private Slider _healthSlider;
    public float MaxHealth => maxHealth;

    [Header("Waypoint Settings")]
    public Transform _enemySpawnPosition;
    protected Vector3 originalPosition;
    protected Vector3 targetPosition;
    protected Vector3 previousPosition;
    protected int _currentWaypointIndex = 0;
    protected int _lastWaypointIndex = 0;
    void Awake()
    {
        enemyPath = GetComponent<EnemyPathing>();
        _healthBar = GetComponent<EnemyHealth>();
        _sr = GetComponent<SpriteRenderer>();
        _healthSlider = _healthBar.healthSlider.GetComponent<Slider>();
    }

    private void Start()
    { 
        if (_enemySpawnPosition != null)
        {
            _enemySpawnPosition = GameObject.Find("StartPoint").transform;
        }

        transform.position = _enemySpawnPosition.position;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ResetPosition()
    {
        transform.position = originalPosition;
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

    protected void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition,
            moveSpeed * Time.deltaTime);
    }

    protected void Rotate()
    {
        if (_lastWaypointIndex == 0)
            return;
        if (targetPosition.x > previousPosition.x)
            _sr.flipX = false;
        else
            _sr.flipX = true;
    }

    protected bool CurrentPointPositionReached()
    {
        float distanceToNextPointPosition = (transform.position - targetPosition).magnitude;

        return distanceToNextPointPosition < 0.1f;

    }

    protected void UpdateCurrentPointIndex()
    {
        int lastWaypointIndex = waypointList.Count - 1;

        if (_currentWaypointIndex < _lastWaypointIndex)
        {
            _currentWaypointIndex++;
            _lastWaypointIndex = _currentWaypointIndex - 1;
            targetPosition = waypointList[_currentWaypointIndex].position;
            previousPosition = waypointList[lastWaypointIndex].position;
        }
            
        else
            EndPointReached();     
    }

    private void EndPointReached()
    {
        ActionSets.OnEnemyReached?.Invoke(this);
        this.ResetHealth();
        ObjectPoolManager.ReturnObjectToPool(gameObject);
    }

    protected void ResetHealth()
    {
        _healthBar.SetHealth(maxHealth);
    }
}
