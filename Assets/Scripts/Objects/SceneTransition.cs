using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

// Scene transition behaviour
public class SceneTransition : MonoBehaviour
{
    [Header("Scene Transition Variables")]
    public string sceneToLoad;
    public Vector2 cameraMinPosition;
    public Vector2 cameraMaxPosition;
    public Vector2 playerPosition;
    public TransitionValues transitionValues;

    [Header("Scene Fade Variables")]
    public GameObject fadeInPanel;
    public GameObject fadeOutPanel;
    public float fadeWait;

    // Create fade panel on scene transition
    private void Awake()
    {
        if (fadeInPanel != null)
        {
            GameObject panel = Instantiate(fadeInPanel, Vector3.zero, Quaternion.identity);
            Destroy(panel, 1);
        }
    }

    // Store transition values on collision
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !collision.isTrigger)
        {
            transitionValues.runtimePlayerPosition = playerPosition;
            transitionValues.runtimeCameraMinPosition = cameraMinPosition;
            transitionValues.runtimeCameraMaxPosition = cameraMaxPosition;
            StartCoroutine(SceneTransitionCo());
        }
    }

    // Transition scenes with fade
    public IEnumerator SceneTransitionCo() 
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