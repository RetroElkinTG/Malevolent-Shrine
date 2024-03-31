using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

// TODO Add custom keybinds
// TODO Add sound effects
// TODO Add more enemy types - orc, red tree
// TODO Add enemy hit indication
// TODO Add new fonts
// TODO Add rendering for tall objects by putting them on new layer
// TODO Add hover effect/highlight menu items

// Game manager behaviour
public class GameManager : MonoBehaviour
{
    [Header("Game Variables")]
    public TransitionValues transitionValues;
    public ObjectValues treasureChest;
    public ObjectValues keyDoor;
    public ObjectValues[] heartPickups;
    public InventoryValues inventory; 
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
        ResetVariables();
        StartCoroutine(SceneTransitionCo(overworld));
    }

    // Quit to main menu
    public void QuitToMainMenu()
    {
        ResetVariables();
        StartCoroutine(SceneTransitionCo(mainMenu));
    }

    // Reset game variables
    public void ResetVariables()
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

    // Scene transition coroutine from pause menu
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