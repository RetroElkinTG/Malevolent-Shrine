using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Pause manager behaviour
public class PauseManager : MonoBehaviour
{
    public static bool gameIsPaused;
    public GameObject pausePanel;

    public string overworld;
    public string mainMenu;

    public TransitionValues playerPositionStorage;

    public GameObject fadeInPanel;
    public GameObject fadeOutPanel;
    public float fadeWait;



    // Set game to not paused
    private void Start()
    {
        gameIsPaused = false;
    }

    // Check if game is paused
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
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

    // Restart level
    public void RestartLevel()
    {
        ResetValues();
        StartCoroutine(SceneTransitionCo(overworld));
    }

    // Quit to main menu
    public void QuitToMainMenu()
    {
        ResetValues();
        StartCoroutine(SceneTransitionCo(mainMenu));
    }

    // Reset scene values
    public void ResetValues()
    {
        playerPositionStorage.runtimePlayerPosition = playerPositionStorage.defaultPlayerPosition;
        playerPositionStorage.runtimeCameraMinPosition = playerPositionStorage.defaultCameraMinPosition;
        playerPositionStorage.runtimeCameraMaxPosition = playerPositionStorage.defaultCameraMaxPosition;
        Time.timeScale = 1f;
    }

    // Transition scenes with fade
    public IEnumerator SceneTransitionCo(string sceneToLoad)
    {
        if (fadeOutPanel != null)
        {
            Instantiate(fadeOutPanel, Vector3.zero, Quaternion.identity);
        }
        yield return new WaitForSeconds(fadeWait);
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneToLoad);
        while (!asyncOperation.isDone)
        {
            yield return null;
        }
    }

    public void Quit()
    {
        Application.Quit();
    }
}
