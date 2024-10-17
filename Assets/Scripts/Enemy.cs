using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 2f;
    public GameObject explosionEffect;
    public int scoreValue = 10;

    private void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        // Destroy the enemy if it moves off the bottom of the screen
        if (transform.position.y < -6f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerBullet"))
        {
            Instantiate(explosionEffect, transform.position, Quaternion.identity);
            Destroy(collision.gameObject); // Destroy the bullet
            Destroy(gameObject); // Destroy the enemy
        }
    }
}
