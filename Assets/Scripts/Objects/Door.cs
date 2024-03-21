using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Door types
public enum DoorType
{
    key,
    enemy,
    button
}

// Door behaviour
public class Door : ObjectManager
{
    [Header("Door Variables")]
    public DoorType myDoorType;
    public bool open = false;
    public Inventory inventory;
    public SpriteRenderer doorSprite;
    public BoxCollider2D boxCollider;

    // Check if player has key
    void Update()
    {
        if (Input.GetButtonDown("Interact"))
        { 
            if (playerInRange && myDoorType == DoorType.key)
            {
                if (inventory.runtimeKeyCount > 0)
                {
                    inventory.runtimeKeyCount--;
                    Open();
                }
            }
        }
    }

    // Open door
    public void Open() 
    {
        doorSprite.enabled = false;
        open = true;
        boxCollider.enabled = false;
    }

    // Close door
    public void Close()
    {

    }
}
