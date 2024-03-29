using UnityEngine;

// Heart behaviour
public class HeartPickup : PickupManager
{
    public HealthValues playerHealth;
    public HealthValues heartContainers;
    public ObjectValues objectValues;
    public int healthIncrease;
    public int healthPerHeartContainer;
    public bool isPickedUp;

    private void Start()
    {
        isPickedUp = objectValues.runtimeHeartIsPickedUp;
        if (isPickedUp)
        {
            gameObject.SetActive(false);
        }
    }

    // Increase Player health on collision
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !collision.isTrigger)
        {
            playerHealth.runtimeValue += healthIncrease;
            if (playerHealth.runtimeValue > heartContainers.runtimeValue * healthPerHeartContainer)
            {
                playerHealth.runtimeValue = heartContainers.runtimeValue * healthPerHeartContainer;
            }
            isPickedUp = true;
            objectValues.runtimeHeartIsPickedUp = isPickedUp;
            pickupSignal.Raise();
            gameObject.SetActive(false);
        }
    }
}