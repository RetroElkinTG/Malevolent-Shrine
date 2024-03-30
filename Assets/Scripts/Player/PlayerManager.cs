using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

// TODO Add sound effects
// TODO More enemy types - orc, red tree
// TODO Code cleanup

// Player states
public enum PlayerState 
{ 
    idle,
    walk,
    interact,
    attack,
    stagger
}

// Player behaviour
public class PlayerManager : MonoBehaviour
{
    [Header("Movement Variables")]
    public PlayerState currentState;
    public float speed;
    private Rigidbody2D myRigidbody;
    public TransitionValues startingPosition;
    private Vector3 myPosition;
    private Animator myAnimator;

    [Header("Health Variables")]
    public HealthValues currentPlayerHealth;
    public SignalSender currentPlayerHealthSignal;
    public SignalSender screenKickSignal;

    [Header("Inventory Variables")]
    public Inventory inventory;
    public SpriteRenderer receivedItemSprite;

    [Header("Death Variables")]
    public GameManager gameManager;
    public GameObject deathAnimation;
    public string mainMenu;
    private float deathDuration = 3f;
    private SpriteRenderer spriteRenderer;
    public GameObject fadeInPanel;
    public GameObject fadeOutPanel;
    public float fadeWait;

    // GetPlayerComponents on scene load
    void Start()
    {
        GetPlayerComponents();
    }

    void Update()
    {
        if (!PauseMenu.gameIsPaused)
        {
            UpdatePlayerAttack();
        }
    }
    // UpdatePlayerState if not paused
    void FixedUpdate()
    {
        if (!PauseMenu.gameIsPaused)
        {
            UpdatePlayerMovement();
        }
    }

    // Get Player components
    void GetPlayerComponents()
    {
        currentState = PlayerState.walk;
        myAnimator = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        myAnimator.SetFloat("moveX", 0);
        myAnimator.SetFloat("moveY", -1);
        transform.position = startingPosition.runtimePlayerPosition;
    }

    // Update Player attack
    void UpdatePlayerAttack()
    {
        if (Input.GetButtonDown("Attack") && currentState != PlayerState.attack
            && currentState != PlayerState.stagger && currentState != PlayerState.interact)
        {
            StartCoroutine(AttackCo());
        }
    }

    // Update Player movement
    void UpdatePlayerMovement()
    {
        if (currentState == PlayerState.interact)
        {
            return;
        }
        myPosition = Vector2.zero;
        myPosition.x = Input.GetAxisRaw("Horizontal");
        myPosition.y = Input.GetAxisRaw("Vertical");
        if (currentState != PlayerState.stagger)
        {
            UpdateAnimation();
        }
    }

    // Set attack animation
    private IEnumerator AttackCo()
    {
        myAnimator.SetBool("attacking", true);
        currentState = PlayerState.attack;
        yield return null;
        myAnimator.SetBool("attacking", false);
        yield return new WaitForSeconds(.33f);
        if (currentState != PlayerState.interact)
        {
            currentState = PlayerState.walk;
        }
    }

    // Update animation
    void UpdateAnimation()
    {
        if (myPosition != Vector3.zero)
        {
            MovePlayer();
            myPosition.x = Mathf.Round(myPosition.x);
            myPosition.y = Mathf.Round(myPosition.y);
            myAnimator.SetFloat("moveX", myPosition.x);
            myAnimator.SetFloat("moveY", myPosition.y);
            myAnimator.SetBool("moving", true);
        }
        else
        {
            myAnimator.SetBool("moving", false);
        }
    }

    // Move the Player
    void MovePlayer()
    {
        myPosition.Normalize();
        myRigidbody.MovePosition(transform.position + myPosition * speed * Time.deltaTime);
    }

    // Damage and knockback Player
    public void DamagePlayer(float knockbackTime, float damage)
    {
        currentPlayerHealth.runtimeValue -= damage;
        currentPlayerHealthSignal.Raise();
        if (currentPlayerHealth.runtimeValue > 0) 
        {
            StartCoroutine(KnockbackTimeCo(knockbackTime));
        }
        else 
        {
            PlayerDeathAnimation();
            myRigidbody.isKinematic = true;
            myRigidbody.velocity = Vector2.zero;
            spriteRenderer.enabled = false;
            gameManager.ResetValues();
            StartCoroutine(SceneTransitionCo(mainMenu));
        }
    }

    // Stop knockback after a specified amount of time
    private IEnumerator KnockbackTimeCo(float knockbackTime)
    {
        screenKickSignal.Raise();
        if (myRigidbody != null)
        {
            yield return new WaitForSeconds(knockbackTime);
            myRigidbody.velocity = Vector2.zero;
            currentState = PlayerState.idle;
        }
    }

    // Player death animation
    private void PlayerDeathAnimation()
    {
        if (deathAnimation != null)
        {
            GameObject animation = Instantiate(deathAnimation, transform.position, Quaternion.identity);
            Destroy(animation, deathDuration);
        }
    }

    // Transition scenes from Player death
    public IEnumerator SceneTransitionCo(string sceneToLoad)
    {
        if (fadeOutPanel != null)
        {
            Instantiate(fadeOutPanel, Vector3.zero, Quaternion.identity);
        }
        yield return new WaitForSeconds(fadeWait);
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneToLoad);
        while (!asyncOperation.isDone)
        {
            yield return null;
        }
    }

    // Raise item
    public void RaiseItem()
    {
        if (inventory.currentItem != null)
        {
            if (currentState != PlayerState.interact)
            {
                myAnimator.SetBool("receiveItem", true);
                currentState = PlayerState.interact;
                receivedItemSprite.sprite = inventory.currentItem.itemSprite;
            }
            else
            {
                myAnimator.SetBool("receiveItem", false);
                currentState = PlayerState.idle;
                receivedItemSprite.sprite = null;
                inventory.currentItem = null;
            }
        }
    }
}