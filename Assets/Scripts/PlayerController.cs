using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{
    [Header("Player Movement")]
    public float moveSpeed = 5f;
    public float maxX = 8f;
    public float fixedYPosition = -4f;

    [Header("Shooting")]
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireRate = 0.5f;
    private float nextFireTime = 0f;

    private bool isDoubleShotActive = false;

    [Header("Health")]
    public int maxHealth = 20;
    private int currentHealth;
    public Slider healthBar;

    private void Start()
    {
        currentHealth = maxHealth;
        
        // Set the max value for the health bar if available
        if (healthBar != null)
        {
            healthBar.minValue = 0; // Ensure the slider starts from 0
            healthBar.maxValue = maxHealth; // Set the slider's max value to the player's max health
            healthBar.value = currentHealth; // Initialize the health bar to display the player's starting health
        }
    }

    void Update()
    {
        Move();
        if (Input.GetKey(KeyCode.Space) && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
    }

    private void Move()
    {
        float moveInput = Input.GetAxis("Horizontal");
        Vector3 moveDirection = new Vector3(moveInput, 0, 0);
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);

        float clampedX = Mathf.Clamp(transform.position.x, -maxX, maxX);
        transform.position = new Vector3(clampedX, fixedYPosition, 0);
    }

    private void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.value = currentHealth;

        if (currentHealth <= 0)
        {
            Debug.Log("Player has been defeated!");
            // Add game over logic here, e.g., reload the scene or display a game over screen
        }
    }

    public void ActivateDoubleShot()
    {
        if (!isDoubleShotActive)
        {
            isDoubleShotActive = true;
            StartCoroutine(DoubleShotCoroutine());
        }
    }

    private IEnumerator DoubleShotCoroutine()
    {
        float originalFireRate = fireRate;
        fireRate /= 2; // Halve the fire rate for double shots (fire twice as fast)
        yield return new WaitForSeconds(5f); // Duration of the double shot power-up
        fireRate = originalFireRate; // Reset to the original fire rate
        isDoubleShotActive = false;
    }
}
