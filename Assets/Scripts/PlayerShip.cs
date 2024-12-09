using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShip : MonoBehaviour
{
    public float thrustForce = 20.0f; // Force for moving forward
    public float rotationSpeed = 200.0f; // Speed of rotation
    private Vector2 velocity = Vector2.zero; // Current velocity
    public AudioSource thrustSound; // Audio source for thrust
    public AudioSource teleportAudioSource; // Reference to the teleport sound


    // Start is called before the first frame update
    void Start()
    {
        
    }
    

    // Update is called once per frame
    void Update()
    {
        // Handle Rotation
        float rotationInput = Input.GetAxis("Horizontal"); // Left/Right Arrow or A/D keys
        transform.Rotate(Vector3.forward * -rotationInput * rotationSpeed * Time.deltaTime);

        // Handle Thrust
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            Vector2 thrust = transform.right * thrustForce * Time.deltaTime; // Forward direction
            velocity += thrust;

        }
        
        if (Input.GetKeyDown(KeyCode.UpArrow)) // start it once when key is pressed for the first time
        {
            thrustSound.loop = true; // Loop the audiostart it once when key is pressed for the first time
            thrustSound.Play(); // Play thrust sound while moving
        }
        else if (Input.GetKeyUp(KeyCode.UpArrow)) // end the audio when the key is released
        {
        thrustSound.loop = false; // end loop to stop
        thrustSound.Stop(); // Stop thrust sound when not moving
        }


        // Apply Friction (damping)
        velocity *= 0.99f;

        // Update Position
        transform.position += (Vector3)velocity * Time.deltaTime;

        // Screen Wrapping
        WrapAroundScreen();


    }
    void WrapAroundScreen()
    {
        Vector3 newPosition = transform.position;
        bool teleported = false; // Track if the ship has teleported
        

        // Wrap the ship around if it goes off screen
        if (newPosition.x > 10.0f)
        {
            newPosition.x = -10.0f; // Teleport to the left side
            teleported = true;
        }
        else if (newPosition.x < -10.0f)
        {
            newPosition.x = 10.0f; // Teleport to the right side
            teleported = true;
        }

        if (newPosition.y > 5.0f)
        {
            newPosition.y = -5.0f; // Teleport to the bottom
            teleported = true;
        }
        else if (newPosition.y < -5.0f)
        {
            newPosition.y = 5.0f; // Teleport to the top
            teleported = true;
        }

        // If the ship has teleported, play the teleport sound
        if (teleported && teleportAudioSource != null)
        {
            teleportAudioSource.Play(); // Play teleport sound
        }

        // Update the ship's position
        transform.position = newPosition;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Asteroid"))
        {
            Destroy(gameObject); // Destroy the player ship
            GameManager.Instance.LoseLife(); // Notify the GameManager
        }
    }
}
