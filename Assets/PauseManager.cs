using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseManager : MonoBehaviour
{
    public GameObject pauseMenuCanvas;
    // Start is called before the first frame update
    void Start()
    {
        pauseMenuCanvas.SetActive(false);   
    }

    // Update is called once per frame
    void Update()
    {
        // Toggle pause menu with Escape key
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
        pauseMenuCanvas.SetActive(true);
        Time.timeScale = 0; // Pause the game
    }
    public void ResumeGame()
    {
        pauseMenuCanvas.SetActive(false);
        Time.timeScale = 1; // Resume the game
    }
    public void ExitGame()
    {

        SceneManager.LoadScene("TitleScene"); // Return to the title screen
    }
}
