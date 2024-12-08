using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public Vector2 velocity; // Velocity of the asteroid
    public AudioClip destroyedClip; // Death sound clip added from inspection
    

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
            
            Destroy(other.gameObject); // Destroy the bullet
            AudioSource.PlayClipAtPoint(destroyedClip, transform.position); //create a position for sound and play it
            AsteroidDestroyed();  // destroy asteroid on a seperate function
  
        }
    }
    
    void AsteroidDestroyed()
    {
        Destroy(gameObject); // Destroy the asteroid
    }

}
