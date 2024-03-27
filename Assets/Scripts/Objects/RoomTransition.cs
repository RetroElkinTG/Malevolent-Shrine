using System.Collections;
using UnityEngine;
using TMPro;

// Room movement behaviour
public class RoomTransition : MonoBehaviour
{
    [Header("Player Transition Variables")]
    private CameraManager cameraMovement;
    public TransitionValues startingCameraPosition;
    public Vector3 playerChange;
    public Vector2 cameraMinChange;
    public Vector2 cameraMaxChange;

    [Header("Location Variables")]
    public GameObject locationTextObject;
    public TextMeshProUGUI locationText;
    public string locationName;
    public bool needText;

    // Start with getting components
    void Start()
    {
        cameraMovement = Camera.main.GetComponent<CameraManager>();
    }

    // Move camera if the player moves rooms - public cameraChange set to min and max if room isn't square
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !collision.isTrigger)
        {
            cameraMovement.minPosition += cameraMinChange;
            cameraMovement.maxPosition += cameraMaxChange;
            startingCameraPosition.runtimeCameraMinPosition = cameraMovement.minPosition;
            startingCameraPosition.runtimeCameraMaxPosition = cameraMovement.maxPosition;
            collision.transform.position += playerChange;
            if (needText)
            {
                StartCoroutine(PlaceNameCo());
            }
        }
    }

    // Display location text for 4 seconds
    private IEnumerator PlaceNameCo()
    {
        locationTextObject.SetActive(true);
        locationText.text = locationName;
        yield return new WaitForSeconds(4f);
        locationTextObject.SetActive(false);
    }
}