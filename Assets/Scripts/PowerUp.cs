using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public float speed = 3f;

    void Update()
    {
        // Move the power-up downwards
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        // Destroy the power-up if it moves off the bottom of the screen
        if (transform.position.y < -6f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the power-up collided with the player
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerController>().ActivateDoubleShot();
            Destroy(gameObject); // Destroy the power-up after being collected
        }
    }
}
