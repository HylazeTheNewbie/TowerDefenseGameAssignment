using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerProjectile : MonoBehaviour
{
    [SerializeField] protected Transform projectileSpawnPosition;
    [SerializeField] protected float delayBetweenAttacks = 1f;
    [SerializeField] protected float damage = 15f;

    public float Damage { get; set; }
    public float DelayPerShot { get; set; }

    protected float _nextAttackTime;
    protected ObjectPoolManager _pooler;
    protected Tower _tower;

    void Start()
    {
        
    }


    void Update()
    {
        
    }
}
