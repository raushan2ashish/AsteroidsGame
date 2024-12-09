using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class GameOverManager : MonoBehaviour
{
    public TextMeshProUGUI finalScoreText; // Reference to the score text

    // Start is called before the first frame update
    void Start()
    {
        // Display the final score (retrieve from GameManager)
        if (GameManager.Instance != null)
        {
            finalScoreText.text = "Final Score: " + GameManager.Instance.GetScore();
        }
        else
        {
            DontDestroyOnLoad(gameObject); // Prevent GameManager from being destroyed

        }
    }

    // Update is called once per frame
    public void Update() 
    {
    
    }
        
    public void RestartGame()
    {
        SceneManager.LoadScene("GameScene"); // Reload the game scene
    }

    public void QuitGame()
    {
        SceneManager.LoadScene("TitleScene"); // Return to the title screen
    }

    
}
