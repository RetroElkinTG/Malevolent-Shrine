using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO Fix enemies loading on scene
// TODO Fix collision glitches
// TODO Fix camera going to player on scene transition
// TODO Fix enemies stacking on each other

// Player states
public enum PlayerState 
{ 
    idle,
    walk,
    interact,
    attack,
    stagger
}

// Player movement behaviour
public class PlayerManager : MonoBehaviour
{
    public PlayerState currentState;
    public float speed;
    private Rigidbody2D myRigidbody;
    private Vector3 myPosition;
    private Animator myAnimator;

    public HeartValues currentPlayerHealth;
    public SignalSender currentPlayerHealthSignal;
    public TransitionValues startingPosition;

    // Get player components
    void Start()
    {
        currentState = PlayerState.walk;
        myAnimator = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator.SetFloat("moveX", 0);
        myAnimator.SetFloat("moveY", -1);
        transform.position = startingPosition.runtimePlayerPosition;
    }

    // Update player state
    void Update()
    {
        myPosition = Vector2.zero;
        myPosition.x = Input.GetAxisRaw("Horizontal");
        myPosition.y = Input.GetAxisRaw("Vertical");
        if (Input.GetButtonDown("Attack") && currentState != PlayerState.attack 
            && currentState != PlayerState.stagger) 
        {
            StartCoroutine(AttackCo());
        }
        else if (currentState == PlayerState.walk || currentState == PlayerState.idle)
        { 
            UpdateAnimationAndMovement();
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
        currentState = PlayerState.walk;
    }

    // Update player animation and movement
    void UpdateAnimationAndMovement()
    {
        if (myPosition != Vector3.zero)
        {
            MoveCharacter();
            myAnimator.SetFloat("moveX", myPosition.x);
            myAnimator.SetFloat("moveY", myPosition.y);
            myAnimator.SetBool("moving", true);
        }
        else
        {
            myAnimator.SetBool("moving", false);
        }
    }

    // Move the player in the direction of input
    void MoveCharacter()
    {
        myPosition.Normalize();
        myRigidbody.MovePosition(transform.position + myPosition * speed * Time.deltaTime);
    }

    // Reduce player health and call knockback
    public void Knockback(float KnockbackTime, float damage)
    {
        currentPlayerHealth.runtimeValue -= damage;
        currentPlayerHealthSignal.Raise();
        if (currentPlayerHealth.runtimeValue > 0) 
        {
            StartCoroutine(KnockbackTimeCo(KnockbackTime));
        }
        else 
        {
            gameObject.SetActive(false);
        }
    }

    // Stop knockback after a specified amount of time
    private IEnumerator KnockbackTimeCo(float knockbackTime)
    {
        if (myRigidbody != null)
        {
            yield return new WaitForSeconds(knockbackTime);
            myRigidbody.velocity = Vector2.zero;
            currentState = PlayerState.idle;
        }
    }
}