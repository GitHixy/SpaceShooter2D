using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player Movement")]
    public float moveSpeed = 5f;
    public float maxX = 8f; // Adjust based on screen size

    [Header("Shooting")]
    public GameObject bulletPrefab;
    public Transform firePoint;
    
    public float fixedYPosition = -4f;
    public float fireRate = 0.5f;
    private float nextFireTime = 0f;

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
        // Get horizontal input only
        float moveInput = Input.GetAxis("Horizontal");
        Vector3 moveDirection = new Vector3(moveInput, 0, 0); // y = 0 to ensure no vertical movement
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);

        // Clamp the player position within screen bounds
        float clampedX = Mathf.Clamp(transform.position.x, -maxX, maxX);
        transform.position = new Vector3(clampedX, fixedYPosition, 0);
    }

    private void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
    }

    public void ActivateDoubleShot()
    {
        StartCoroutine(DoubleShotCoroutine());
    }

    private IEnumerator DoubleShotCoroutine()
    {
        fireRate /= 2; // Faster shooting for double shot
        yield return new WaitForSeconds(5f); // Duration of the power-up
        fireRate *= 2; // Reset to normal
    }

}
