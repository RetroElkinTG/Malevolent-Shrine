using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RoomMove : MonoBehaviour
{
    public Vector2 cameraChange;
    public Vector3 playerChange;
    private CameraMovement cameraMovement;
    //public bool needText;
    //public string placeName;
    //public GameObject text;
    //public TextMeshPro placeText;

    // Start with getting camera components
    void Start()
    {
        cameraMovement = Camera.main.GetComponent<CameraMovement>();
        //TextMeshPro textmeshPro = GetComponent<TextMeshPro>();
        //textmeshPro.outlineWidth = 0.2f;
        //textmeshPro.outlineColor = new Color32(255, 128, 0, 255);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Move camera if the player moves rooms - public cameraChange set to min and max if room isn't square
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            cameraMovement.minPosition += cameraChange;
            cameraMovement.maxPosition += cameraChange;
            collision.transform.position += playerChange;
            //if (needText)
            //{

            //}
        }
    }

    //private IEnumerator PlaceNameCo()
    //{
    //    text.SetActive(true);
    //}
}
