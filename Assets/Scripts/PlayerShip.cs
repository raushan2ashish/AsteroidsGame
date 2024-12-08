using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShip : MonoBehaviour
{
    public float thrustForce = 5.0f; // Force for moving forward
    public float rotationSpeed = 200.0f; // Speed of rotation
    private Vector2 velocity = Vector2.zero; // Current velocity
    public AudioSource thrustSound; // Audio source for thrust
    


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

        // Adjust for screen bounds
        if (newPosition.x > 10.0f) newPosition.x = -10.0f;
        if (newPosition.x < -10.0f) newPosition.x = 10.0f;
        if (newPosition.y > 5.0f) newPosition.y = -5.0f;
        if (newPosition.y < -5.0f) newPosition.y = 5.0f;

        transform.position = newPosition;
    }
}
