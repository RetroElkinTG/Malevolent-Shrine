using UnityEngine;
using TMPro;

// Sign behaviour
public class Sign : ObjectManager
{
    [Header("Sign Variables")]
    public GameObject dialogBox;
    public TextMeshProUGUI dialogText;
    public string dialog;

    // Activate text if Player interacts with sign
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

    // Remove text if Player leaves range
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