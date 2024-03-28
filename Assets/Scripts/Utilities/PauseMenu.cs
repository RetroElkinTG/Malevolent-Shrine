using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Pause menu behaviour
public class PauseMenu : GameManager
{
    public static bool gameIsPaused;
    public GameObject pausePanel;

    // Start is called before the first frame update
    void Start()
    {
        gameIsPaused = false;
    }

    // Check if game is paused
    void Update()
    {
        if (Input.GetButtonDown("Cancel") && PlayerManager.isInputEnabled)
        {
            PauseGame();
        }
    }

    // Pause game
    public void PauseGame()
    {
        gameIsPaused = !gameIsPaused;
        if (gameIsPaused)
        {
            Time.timeScale = 0f;
            pausePanel.SetActive(true);
        }
        else
        {
            pausePanel.SetActive(false);
            Time.timeScale = 1f;
        }
    }
}
