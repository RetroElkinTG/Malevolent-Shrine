using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Game manager behaviour
public class GameManager : MonoBehaviour
{
    public string overworld;
    public string mainMenu;

    public TransitionValues transitionValues;
    public ObjectValues objectValues;
    public Inventory inventory; 
    public HealthValues health;

    public GameObject fadeInPanel;
    public GameObject fadeOutPanel;
    public float fadeWait;

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
        transitionValues.runtimePlayerPosition = transitionValues.defaultPlayerPosition;
        transitionValues.runtimeCameraMinPosition = transitionValues.defaultCameraMinPosition;
        transitionValues.runtimeCameraMaxPosition = transitionValues.defaultCameraMaxPosition;
        health.runtimeValue = health.defaultValue;
        inventory.runtimeKeyCount = inventory.defaultKeyCount;
        objectValues.runtimeChestIsOpen = objectValues.defaultChestIsOpen;
        Time.timeScale = 1f;
    }

    // Transition scenes
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

    // Quit application
    public void Quit()
    {
        Application.Quit();
    }
}