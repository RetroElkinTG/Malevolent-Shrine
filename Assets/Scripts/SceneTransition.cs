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
    public PlayerVectorValue playerPositionStorage;

    // Start is called before the first frame update
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !collision.isTrigger)
        {
            playerPositionStorage.initialValue = playerPosition;
            playerPositionStorage.initialMinPositionValue = cameraMinPosition;
            playerPositionStorage.initialMaxPositionValue = cameraMaxPosition;
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}