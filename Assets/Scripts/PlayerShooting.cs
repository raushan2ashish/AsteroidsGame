using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletPrefab; // Reference to the bullet prefab
    public float bulletSpeed = 10.0f; // Speed of the bullet
    public Transform bulletSpawnPoint; // Point from which bullets are fired
    public AudioSource shootSound; // Reference to the audio source for shooting

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Shoot a bullet when the spacebar is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }
    void Shoot()
    {
        // Instantiate the bullet at the spawn point
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, transform.rotation);

        // Assign velocity to the bullet
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * bulletSpeed;

        shootSound.Play(); // Play the shooting sound

        // Destroy the bullet after 3 seconds to save resources
        Destroy(bullet, 3.0f);
    }
}
