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
        lives = 5;
        // Ensure there is only one instance of GameManager
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Prevent GameManager from being destroyed
        }
        else
        {
            Destroy(gameObject);
        }
    }


    private void Start()
    {
        // Reset the lives when the game starts
        lives = 5;
        UpdateUI();
    }
    public void AddScore(int points)
    {
        score += points;
        UpdateUI();
    }
    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Reassign the UI references in the new scene
        scoreText = GameObject.Find("ScoreText")?.GetComponent<TextMeshProUGUI>();
        livesText = GameObject.Find("LivesText")?.GetComponent<TextMeshProUGUI>();

        if (scoreText == null || livesText == null)
        {
            Debug.LogWarning("UI references could not be found in the new scene.");
        }

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
        if(scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
        else
        {
            Debug.LogWarning("ScoreText reference is missing in GameManager.");
        }

        if (livesText != null)
        {
            livesText.text = "Lives: " + lives;
        }
        else
        {
            Debug.LogWarning("LivesText reference is missing in GameManager.");
        }
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
    public int GetScore()
    {
        return score; // Return the current score
    }
}