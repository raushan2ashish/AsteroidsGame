using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using Unity.VisualScripting;

public class GameManager : MonoBehaviour
{
    public GameObject playerShipPrefab; // Reference to the PlayerShip prefab
    public static GameManager Instance; // Singleton instance for global access
    public TextMeshProUGUI scoreText; // Reference to the score UI element
    private int score = 0; // Player's current score
    public TextMeshProUGUI livesText; // UI for the lives
    private int lives = 5; // Player starts with 5 lives

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

    
    private void Start()
    {
        UpdateUI();
    }
    public void AddScore(int points)
    {
        score += points;
        UpdateUI();
    }

    public void LoseLife()
    {
        lives--; // Reduce lives by 1
        UpdateUI();

        if (lives <= 0)
        {
            GameOver();
        }
        else
        {
            RespawnPlayer();
        }
    }

    void UpdateUI()
    {
        scoreText.text = "Score: " + score;
        livesText.text = "Lives: " + lives;
    }

    void RespawnPlayer()
    {
        if (playerShipPrefab != null)
        {
            Instantiate(playerShipPrefab, Vector3.zero, Quaternion.identity); // Spawn at the center
        }
        else
        {
            Debug.LogError("PlayerShip prefab is not assigned in the GameManager.");
        }
    }

    void GameOver()
    {
        SceneManager.LoadScene("GameOverScene"); // Transition to a Game Over scene
    }
}
