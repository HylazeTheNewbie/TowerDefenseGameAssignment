using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyMovement : MonoBehaviour
{
    [Header("References")]
    public Rigidbody2D rb;

    [Header("Attributes")]
    [SerializeField] private float moveSpeed = 2f;

    private Transform target;
    private List<Transform> path;
    private int targetIndex = 0;

    [Header("Path Tag")]
    [SerializeField] private string pathTag;  // Tag of the path to follow

    void Start()
    {
        // Get the path for this enemy based on the tag
        path = EnemyPathing.main.GetPathByTag(pathTag);
        if (path == null || path.Count == 0)
        {
            Debug.LogError($"No path found for tag '{pathTag}'.");
            return;
        }

        target = path[targetIndex];
    }

    void Update()
    {
        // Check if the enemy has reached the target
        float distance = Vector2.Distance(transform.position, target.position);
        if (distance <= 0.1f)
        {
            targetIndex++;

            if (targetIndex >= path.Count)
            {
                // If reached the end of the path, stop moving
                EnemySpawner.onEnemyDestroyed.Invoke();
                Destroy(gameObject);
                return;
            }
            else
            {
                target = path[targetIndex];
            }
        }
    }

    void FixedUpdate()
    {
        // Move towards the target
        Vector2 direction = (target.position - transform.position).normalized;
        rb.velocity = direction * moveSpeed;
    }
}
