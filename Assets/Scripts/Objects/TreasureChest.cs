using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// Treasure chest behaviour
public class TreasureChest : ObjectManager
{
    public Item contents;
    public Inventory inventory;
    public bool isOpen;
    public SignalSender raiseItem;
    public GameObject dialogBox;
    public TextMeshProUGUI dialogText;
    private Animator myAnimator;

    // Start is called before the first frame update
    void Start()
    {
        myAnimator = GetComponent<Animator>();
    }

    // Check for interaction
    void Update()
    {
        if (Input.GetButtonDown("Interact") && playerInRange)
        {
            if (!isOpen) 
            {
                OpenChest();
            }
            else
            {
                ChestOpened();
            }
        }
    }

    // Open chest and send item to player
    public void OpenChest()
    {
        dialogBox.SetActive(true);
        dialogText.text = contents.itemDescription;
        inventory.AddItem(contents);
        inventory.currentItem = contents;
        raiseItem.Raise();
        context.Raise();
        isOpen = true;
        myAnimator.SetBool("opened", true);
    }

    // Chest is already opened
    public void ChestOpened()
    {
        dialogBox.SetActive(false);
        raiseItem.Raise();
    }

    // Check if player enters range
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !collision.isTrigger && !isOpen)
        {
            context.Raise();
            playerInRange = true;
        }
    }

    // Check if player leaves range
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !collision.isTrigger && !isOpen)
        {
            context.Raise();
            playerInRange = false;
        }
    }
}