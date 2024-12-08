using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public GameObject asteroidPrefab; // Reference to the asteroid prefab
    public int asteroidCount = 12; // Number of asteroids to spawn

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < asteroidCount; i++)
        {
            // Spawn asteroids at random positions
            Vector2 randomPosition = new Vector2(
                Random.Range(-9.0f, 9.0f),
                Random.Range(-4.5f, 4.5f)
            );

            GameObject asteroid = Instantiate(asteroidPrefab, randomPosition, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
