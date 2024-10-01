using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Virus : MonoBehaviour
{
    [SerializeField] private float maxHealth = 50f;
    [SerializeField] private float currentHealth = 50f;

    private EnemyHealth _healthBar;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        _healthBar = GetComponent<EnemyHealth>();
        _healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(20);
        }
    }

    void TakeDamage(float damage)
    {
        currentHealth -= damage;
        _healthBar.SetHealth(currentHealth);
    }
}
