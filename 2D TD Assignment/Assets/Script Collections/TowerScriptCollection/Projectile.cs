using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public static Action<Enemy, float> OnEnemyHit;

    [SerializeField] protected float movespeed = 10f;
    [SerializeField] protected float minDistanceDealDamage = 0.1f;
    
    // public AntivirusProjectile projectileOwner { get; set; }
    public float damage { get; set; }
    protected Enemy enemyTarget;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (enemyTarget != null)
        {
            MoveProjectile();
            RotateProjectile();
        }
    }

    protected virtual void MoveProjectile()
    {
        transform.position = Vector2.MoveTowards(transform.position, enemyTarget.transform.position,
            movespeed * Time.deltaTime);
        float distanceToTarget = (enemyTarget.transform.position - transform.position).magnitude;

        if (distanceToTarget < minDistanceDealDamage)
        {
            OnEnemyHit?.Invoke(enemyTarget, damage);
            // enemyTarget.EnemyHealth.DealDamage(damage);
            // projectileOwner.ResetTowerProjectile();
            ObjectPooler.ReturnToPool(gameObject);
        }
    }

    private void RotateProjectile()
    {
        Vector3 enemyPos = enemyTarget.transform.position - transform.position;
        float angle = Vector3.SignedAngle(transform.up, enemyPos, transform.forward);
        transform.Rotate(0f, 0f, angle);
    }

    public void SetEnemy(Enemy enemy)
    {
        enemyTarget = enemy;
    }

    private void ResetTowerProjectile()
    {
        enemyTarget = null;

    }
}
