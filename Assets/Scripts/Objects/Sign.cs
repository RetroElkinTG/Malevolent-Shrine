using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// Sign behaviour
public class Sign : Interactable
{
    public GameObject dialogBox;
    public TextMeshProUGUI dialogText;
    public string dialog;

    // Activate dialog on interact
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

    // Check if player leaves sign range
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !collision.isTrigger)
        {
            context.Raise();
            playerInRange = false;
            dialogBox.SetActive(false);
        }
    }
}