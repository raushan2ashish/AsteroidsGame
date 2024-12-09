using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuCanvas; // Reference to the Pause Menu Canvas

    // Start is called before the first frame update
    void Start()
    {
        // Hide the pause menu at the start
        pauseMenuCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // Toggle pause menu on 'Esc' key press
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseMenuCanvas.activeSelf)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }
    public void PauseGame()
    {
        // Pause the game and show the pause menu
        Time.timeScale = 0f; // Stops all game activities
        pauseMenuCanvas.SetActive(true); // Show the pause menu
    }
    public void ResumeGame()
    {
        // Resume the game and hide the pause menu
        Time.timeScale = 1f; // Resumes all game activities
        pauseMenuCanvas.SetActive(false); // Hide the pause menu
    }
    public void ExitGame()
    {
        // Return to the title screen or exit the game
        SceneManager.LoadScene("TitleScene"); // Or use Application.Quit() for built version
    }
}
