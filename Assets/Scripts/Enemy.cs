using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 2f;
    public int maxHealth = 4; // Total health of the enemy
    private int currentHealth;

    public GameObject explosionEffect; // Assign this in the Inspector with your explosion prefab
    public GameObject enemyBulletPrefab; // Assign the enemy bullet prefab here

    public Transform firePoint; // Position from where the enemy shoots
    public float fireRateMin = 2f; // Minimum time between shots
    public float fireRateMax = 5f; // Maximum time between shots
    private float nextFireTime;

    private void Start()
    {
        currentHealth = maxHealth;
        SetRandomFireTime(); // Initialize the random time for the first shot
    }

    private void Update()
    {
        // Move the enemy downwards
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        // Destroy the enemy if it moves off the bottom of the screen
        if (transform.position.y < -6f)
        {
            Destroy(gameObject);
        }

        // Shooting logic for the enemy
        if (Time.time >= nextFireTime)
        {
            Shoot();
            SetRandomFireTime(); // Reset the fire time for the next shot
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        // Instantiate explosion effect if one is assigned
        if (explosionEffect != null)
        {
            Instantiate(explosionEffect, transform.position, Quaternion.identity);
        }
        Destroy(gameObject); // Destroy the enemy object
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the object colliding with the enemy has the tag "PlayerBullet"
        if (collision.CompareTag("PlayerBullet"))
        {
            TakeDamage(2); // Each player bullet deals 2 damage
            Destroy(collision.gameObject); // Destroy the bullet on impact
        }
    }

    private void Shoot()
    {
        if (firePoint != null && enemyBulletPrefab != null)
        {
            Instantiate(enemyBulletPrefab, firePoint.position, Quaternion.identity);
        }
    }

    private void SetRandomFireTime()
    {
        float randomInterval = Random.Range(fireRateMin, fireRateMax);
        nextFireTime = Time.time + randomInterval;
    }
}
