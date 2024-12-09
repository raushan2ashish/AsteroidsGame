using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusicManager : MonoBehaviour
{
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        // Get the AudioSource component attached to this GameObject
        audioSource = GetComponent<AudioSource>();

        // Play the background music
        if (audioSource != null)
        {
            audioSource.Play();
        }
        else
        {
            Debug.LogError("No AudioSource component found on BackgroundMusic GameObject.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
