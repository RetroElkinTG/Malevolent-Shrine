using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Scene transition behaviour
public class SceneTransition : MonoBehaviour
{
    public string sceneToLoad;
    public Vector2 cameraMinPosition;
    public Vector2 cameraMaxPosition;
    public Vector2 playerPosition;

    public TransitionValues playerPositionStorage;

    public GameObject fadeInPanel;
    public GameObject fadeOutPanel;
    public float fadeWait;

    // Create fade panel on scene transition
    private void Awake()
    {
        if (fadeInPanel != null)
        {
            GameObject panel = Instantiate(fadeInPanel, Vector3.zero, Quaternion.identity) as GameObject;
            Destroy(panel, 1);
        }
    }

    // Store player values on collision
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !collision.isTrigger)
        {
            playerPositionStorage.runtimePlayerPosition = playerPosition;
            playerPositionStorage.runtimeCameraMinPosition = cameraMinPosition;
            playerPositionStorage.runtimeCameraMaxPosition = cameraMaxPosition;
            StartCoroutine(FadeCo());
        }
    }

    // Fade while loading
    public IEnumerator FadeCo() 
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
}