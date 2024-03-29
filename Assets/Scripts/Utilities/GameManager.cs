using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

// Game manager behaviour
public class GameManager : MonoBehaviour
{
    [Header("Game Variables")]
    public TransitionValues transitionValues;
    public ObjectValues treasureChest;
    public ObjectValues keyDoor;
    public ObjectValues[] heartPickups;
    public Inventory inventory; 
    public HealthValues playerHealth;

    [Header("Scene Transition Variables")]
    public string overworld;
    public string mainMenu;
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
        playerHealth.runtimeValue = playerHealth.defaultValue;
        inventory.runtimeKeyCount = inventory.defaultKeyCount;
        treasureChest.runtimeChestIsOpen = treasureChest.defaultChestIsOpen;
        keyDoor.runtimeDoorIsOpen = keyDoor.defaultDoorIsOpen;
        foreach (ObjectValues heartPickup in heartPickups)
        {
            heartPickup.runtimeHeartIsPickedUp = heartPickup.defaultHeartIsPickedUp;

        }
        Time.timeScale = 1f;
    }

    // Transition scenes from menu
    private IEnumerator SceneTransitionCo(string sceneToLoad)
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