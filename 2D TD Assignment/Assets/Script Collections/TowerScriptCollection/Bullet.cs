using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("Bullet Attributes")]
    public float damage;
    public float speed = 80f;
    public float explsionRadius = 0f;

    private Transform target;

    void Start()
    {

    }

    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }

    public void SeekTarget(Transform _target)
    {
        target = _target;
    }

    private void HitTarget()
    {
        if (explsionRadius > 0f)
        {
            Explode();  
        }
        else
        {
            Damage(target);
        }

        Destroy(gameObject); 
    }

    void Explode()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, explsionRadius);

        foreach (Collider2D collider in colliders)
        {
            if (collider.tag == "Enemy")
            {
                Damage(collider.transform);
            }
        }
    }

    void Damage(Transform enemy)
    {
        Enemy e = enemy.GetComponent<Enemy>();
        
        if (e != null)      
            e.ReceiveDamage(damage);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explsionRadius);
    }
}
