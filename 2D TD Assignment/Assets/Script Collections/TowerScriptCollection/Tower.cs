using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;

public class Tower : MonoBehaviour
{
    SoundManager audioManager;

    [Header("Tower Attributes")]
    public float fireRate;
    private float fireCooldown = 0f;
    public float range;
    public bool hiddenDetection;
    public float turnSpeed;

    [Header("References")]
    public Transform target;
    public Transform partToRotate;
    public GameObject bulletPrefab;
    public Transform firePoint;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<SoundManager>();
    }

    // Start is called before the first frame update
    private void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    private void FixedUpdate()
    {
        if (target == null) return;

        TowerRotation();
        CalculateFireCooldown();
    }

    private void CalculateFireCooldown()
    {
        if (fireCooldown <= 0f)
        {
            Shoot();
            fireCooldown = 1f / fireRate;
        }

        fireCooldown -= Time.deltaTime;
    }

    private void Shoot()
    {
        audioManager.PlaySFX(audioManager.shoot);
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();

        if (bullet != null) { 
            bullet.SeekTarget(target);
        }
    }
    private void UpdateTarget()
    {
        Enemy[] enemies = GameObject.FindObjectsOfType<Enemy>(); 
        List<Enemy> validTargets = new List<Enemy>();
        float shortestDistance = Mathf.Infinity;
        Enemy nearestEnemy = null;

        foreach(Enemy enemy in enemies)
        {
            if (enemy.ReturnIsHiddenEnemy() == true && !hiddenDetection)
                continue;
            else
                validTargets.Add(enemy);
        }

        foreach(Enemy enemy in validTargets)
        {
            float distanceToEnemy = Vector2.Distance(transform.position, enemy.transform.position);
            
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if  (nearestEnemy != null && shortestDistance <= range)
            target = nearestEnemy.transform;
        else
            target = null;
    }

    private void TowerRotation()
    {

        Vector3 direction = target.position - partToRotate.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, angle - 90f));
        partToRotate.rotation = Quaternion.RotateTowards(partToRotate.rotation, targetRotation, turnSpeed * Time.fixedDeltaTime);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
