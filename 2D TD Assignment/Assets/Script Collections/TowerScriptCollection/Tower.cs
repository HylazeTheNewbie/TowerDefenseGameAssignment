using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tower : MonoBehaviour
{
    [SerializeField] protected float range;
    [SerializeField] protected bool hiddenDetection;

    protected CircleCollider2D circleCollider2D;
    protected List<Enemy> enemies;
    protected Enemy currentEnemyTarget;
    // Start is called before the first frame update
    private void Start()
    {
        circleCollider2D = GetComponent<CircleCollider2D>();
        circleCollider2D.isTrigger = true;
        circleCollider2D.radius = range;
    }

    // Update is called once per frame
    private void Update()
    {

    }

    protected void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Enemy newEnemy = other.GetComponent<Enemy>();

            if (newEnemy.ReturnIsHiddenEnemy() == true && !hiddenDetection)
                return;

            enemies.Add(newEnemy);
        }
    }
    
    protected void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Enemy") )
        {
            Enemy enemy = other.GetComponent<Enemy>();
            if (enemies.Contains(enemy))
            {
                enemies.Remove(enemy);
            }
        }
    }

    protected void GetCurrentEnemyTarget()
    {
        if (enemies.Count <= 0)
        {
            currentEnemyTarget = null;
            return;
        }

        currentEnemyTarget = enemies[0];
    }
    protected void RotateTowards(GameObject target)
    {
        Vector3 direction = target.transform.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
}
