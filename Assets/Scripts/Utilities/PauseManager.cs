using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Pause manager behaviour
public class PauseManager : MonoBehaviour
{
    public static bool gameIsPaused;

    // Check if game is paused
    void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            gameIsPaused = !gameIsPaused;
            PauseGame();
        }
    }

    // Pause game
    void PauseGame()
    {
        if (gameIsPaused) 
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1;
        }
    }
}
