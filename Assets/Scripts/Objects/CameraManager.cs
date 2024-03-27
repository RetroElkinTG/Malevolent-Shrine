using UnityEngine;

// Camera behaviour
public class CameraManager : MonoBehaviour
{
    [Header("Camera Movement Variables")]
    public Transform target;
    public float smoothing;
    public Vector2 minPosition;
    public Vector2 maxPosition;

    [Header("Camera Position Storage Variables")]
    public TransitionValues startingCameraPosition;

    // Set camera to player
    private void Start()
    {
        transform.position = new Vector3(startingCameraPosition.runtimePlayerPosition.x, 
            startingCameraPosition.runtimePlayerPosition.y, transform.position.z);
        minPosition = startingCameraPosition.runtimeCameraMinPosition;
        maxPosition = startingCameraPosition.runtimeCameraMaxPosition;
    }

    // Bound camera and smoothly follow player movement
    void LateUpdate()
    {
        if (transform.position != target.position) 
        { 
            Vector3 targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z);
            targetPosition.x = Mathf.Clamp(targetPosition.x, minPosition.x, maxPosition.x);
            targetPosition.y = Mathf.Clamp(targetPosition.y, minPosition.y, maxPosition.y);
            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing);
        }
    }
}