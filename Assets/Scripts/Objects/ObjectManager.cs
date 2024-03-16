using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Object manager behaviour
public class ObjectManager : MonoBehaviour
{
    public bool playerInRange;
    public SignalSender context;

    // Check if player enters range
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !collision.isTrigger)
        {
            context.Raise();
            playerInRange = true;
        }
    }

    // Check if player leaves range
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !collision.isTrigger)
        {
            context.Raise();
            playerInRange = false;
        }
    }
}