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
    public bool isOpen = false;
    public Inventory inventory;
    public ObjectValues objectValues;
    public SpriteRenderer doorSprite;
    public BoxCollider2D boxCollider;

    void Start()
    {
        isOpen = objectValues.runtimeDoorIsOpen;
        if (isOpen)
        {
            doorSprite.enabled = false;
            boxCollider.enabled = false;
            gameObject.SetActive(false);
        }
    }

    // Check if key is in inventory
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
        isOpen = true;
        objectValues.runtimeDoorIsOpen = isOpen;
        doorSprite.enabled = false;
        boxCollider.enabled = false;
        gameObject.SetActive(false);
    }
}