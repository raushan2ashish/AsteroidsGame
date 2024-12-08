using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; // Singleton instance for global access
    public TextMeshProUGUI scoreText; // Reference to the score UI element
    private int score = 0; // Player's current score

    void Awake()
    {
        // Ensure there is only one instance of GameManager
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddScore(int points)
    {
        score += points; // Increase the score
        scoreText.text = "Score: " + score; // Update the UI
    }
}
