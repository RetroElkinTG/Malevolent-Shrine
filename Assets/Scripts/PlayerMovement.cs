using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState 
{ 
    walk,
    attack,
    interact
}

public class PlayerMovement : MonoBehaviour
{
    public PlayerState currentState;
    public float speed;
    private Rigidbody2D myRigidbody;
    private Vector3 myPosition;
    private Animator myAnimator;

    // Start with getting player components
    void Start()
    {
        myAnimator = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update player position each frame
    void Update()
    {
        myPosition = Vector3.zero;
        myPosition.x = Input.GetAxisRaw("Horizontal");
        myPosition.y = Input.GetAxisRaw("Vertical");
        if (Input.GetButtonDown("Attack") && currentState != PlayerState.attack) 
        {
            StartCoroutine(AttackCo());
        }
        else if (currentState == PlayerState.walk)
        { 
            UpdateAnimationAndMovement();
        }
    }

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
        myRigidbody.MovePosition(transform.position + myPosition * speed * Time.deltaTime);
    }
}