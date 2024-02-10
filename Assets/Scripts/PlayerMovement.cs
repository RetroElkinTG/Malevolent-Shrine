using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
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

    // Update player movement each frame
    void Update()
    {
        myPosition = Vector3.zero;
        myPosition.x = Input.GetAxisRaw("Horizontal");
        myPosition.y = Input.GetAxisRaw("Vertical");
        UpdateAnimationAndMovement();
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
        myRigidbody.MovePosition(
            transform.position + myPosition * speed * Time.deltaTime);
    }
}
