using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// Room movement behaviour
public class RoomMove : MonoBehaviour
{
    public Vector2 cameraChange;
    public Vector3 playerChange;
    private CameraMovement cameraMovement;
    public bool needText;
    public string locationName;
    public GameObject text;
    public TextMeshProUGUI locationText;

    // Start with getting components
    void Start()
    {
        cameraMovement = Camera.main.GetComponent<CameraMovement>();
    }

    // Move camera if the player moves rooms - public cameraChange set to min and max if room isn't square
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            cameraMovement.minPosition += cameraChange;
            cameraMovement.maxPosition += cameraChange;
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
        text.SetActive(true);
        locationText.text = locationName;
        yield return new WaitForSeconds(4f);
        text.SetActive(false);
    }
}