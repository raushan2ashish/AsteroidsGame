using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public Vector2 velocity; // Velocity of the asteroid
    public AudioClip destroyedClip; // Death sound clip added from inspection
    public GameObject asteroidMediumPrefab; // Reference to the medium asteroid prefab
    public GameObject asteroidSmallPrefab;  // Reference to the small asteroid prefab
    public GameObject explosionEffect;      // Particle effect prefab for explosion

    // Start is called before the first frame update
    void Start()
    {
        // Assign a random direction and speed
        float randomSpeed = Random.Range(1.0f, 3.0f);
        float randomAngle = Random.Range(0, 360);
        velocity = new Vector2(
            Mathf.Cos(randomAngle * Mathf.Deg2Rad) * randomSpeed,
            Mathf.Sin(randomAngle * Mathf.Deg2Rad) * randomSpeed
        );
    }

    // Update is called once per frame
    void Update()
    {
        // Move the asteroid
        transform.position += (Vector3)velocity * Time.deltaTime;

        // Wrap around the screen
        WrapAroundScreen();
    }
    void WrapAroundScreen()
    {
        Vector3 newPosition = transform.position;

        // Adjust for screen bounds
        if (newPosition.x > 10.0f) newPosition.x = -10.0f;
        if (newPosition.x < -10.0f) newPosition.x = 10.0f;
        if (newPosition.y > 5.0f) newPosition.y = -5.0f;
        if (newPosition.y < -5.0f) newPosition.y = 5.0f;

        transform.position = newPosition;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the asteroid was hit by a bullet
        if (other.CompareTag("Bullet"))
        {
            // Instantiate the explosion effect
            if (explosionEffect != null)
            {
                GameObject explosion = Instantiate(explosionEffect, transform.position, Quaternion.identity);
                Destroy(explosion, 1.0f); // Destroy the particle system after 1 second
            }

            // Check the size of the asteroid and split if applicable
            if (gameObject.name.Contains("Large"))
            {
                SplitAsteroid(asteroidMediumPrefab); // Spawn medium asteroids
                GameManager.Instance.AddScore(100);
                SplitAsteroid(asteroidMediumPrefab);
            }
            else if (gameObject.name.Contains("Medium"))
            {
                SplitAsteroid(asteroidSmallPrefab); // Spawn small asteroids
                GameManager.Instance.AddScore(50);
                SplitAsteroid(asteroidSmallPrefab);
            }
            else if (gameObject.name.Contains("Small"))
            {
                GameManager.Instance.AddScore(25);
            }

            Destroy(other.gameObject); // Destroy the bullet
            AudioSource.PlayClipAtPoint(destroyedClip, transform.position); //create a position for sound and play it
            AsteroidDestroyed();  // destroy asteroid on a seperate function
  
        }
    }
    
    void AsteroidDestroyed()
    {
        Destroy(gameObject); // Destroy the asteroid
    }
    void SplitAsteroid(GameObject smallerAsteroidPrefab)
    {
        // Spawn two smaller asteroids
        for (int i = 0; i < 1; i++)
        {
            GameObject newAsteroid = Instantiate(smallerAsteroidPrefab, transform.position, Quaternion.identity);

            // Assign random velocity to each new asteroid
            float randomSpeed = Random.Range(1.5f, 3.5f);
            float randomAngle = Random.Range(0, 360);
            Vector2 newVelocity = new Vector2(
                Mathf.Cos(randomAngle * Mathf.Deg2Rad) * randomSpeed,
                Mathf.Sin(randomAngle * Mathf.Deg2Rad) * randomSpeed
            );

            newAsteroid.GetComponent<Asteroid>().velocity = newVelocity;
        }
    }

}
