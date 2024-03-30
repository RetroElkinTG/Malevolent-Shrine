using UnityEngine;

// Death sign behaviour
public class DeathSign : Sign
{
    [Header("Death Sign Variables")]
    public PlayerManager playerManager;
    private bool isRead;
    private float knockbackTime = 0;
    public int damage;
    public float damageDelay;
    private float damageDelaySeconds;

    // Kill the player once read
    void Update()
    {
        if (Input.GetButtonDown("Interact") && playerInRange)
        {
            if (dialogBox.activeInHierarchy)
            {
                dialogBox.SetActive(false);
                isRead = true;
            }
            else
            {
                dialogBox.SetActive(true);
                dialogText.text = dialog;
            }
        }
        if (isRead)
        {
            damageDelaySeconds -= Time.deltaTime;
            if (damageDelaySeconds <= 0) 
            {
                playerManager.DamagePlayer(knockbackTime, damage);
                damageDelaySeconds = damageDelay;
            }
        }
    }
}
