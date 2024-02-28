using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Sign : MonoBehaviour
{
    public GameObject dialogBox;
    public TextMeshProUGUI dialogText;
    public string dialog;
    public bool playerInRange;

    // Check if player interacts with sign
    void Update()
    {
        if (Input.GetButtonDown("Interact") && playerInRange)
        { 
            if (dialogBox.activeInHierarchy)
            { 
                dialogBox.SetActive(false);
            }
            else 
            { 
                dialogBox.SetActive(true);
                dialogText.text = dialog;
            }
        }
    }

    // Check if player enters sign range
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    // Check if player leaves sign range
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = false;
            dialogBox.SetActive(false);
        }
    }
}