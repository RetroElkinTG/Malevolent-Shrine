using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Log behaviour
public class Log : Enemy
{
    private Rigidbody2D myRigidbody;
    public Transform targetPosition;
    public float chaseRadius;
    public float attackRadius;
    public Transform homePosition;
    private Animator myAnimator;

    // Start is called before the first frame update
    void Start()
    {
        currentState = EnemyState.idle;
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        targetPosition = GameObject.FindWithTag("Player").transform;
    }

    // FixedUpdate is called once per physics frame
    void FixedUpdate()
    {
        CheckDistance();
    }

    // Check distance between enemy and player then move towards player
    void CheckDistance()
    {
        if (Vector2.Distance(targetPosition.position, transform.position) <= chaseRadius &&
            Vector2.Distance(targetPosition.position, transform.position) > attackRadius)
        {
            if (currentState == EnemyState.idle || currentState == EnemyState.walk
                && currentState != EnemyState.stagger)
            {
                Vector3 targetDirection = Vector2.MoveTowards(transform.position, targetPosition.position,
                    enemyMovementSpeed * Time.deltaTime);
                // Update animation
                UpdateAnimation(targetDirection - transform.position);
                myRigidbody.MovePosition(targetDirection);
                ChangeState(EnemyState.walk);
                myAnimator.SetBool("wakeUp", true);
            }
        }
        else if (Vector2.Distance(targetPosition.position, transform.position) > chaseRadius)
        {
            myAnimator.SetBool("wakeUp", false);
        }
    }

    // Update Animation
    private void UpdateAnimation(Vector2 direction)
    { 
        direction = direction.normalized;
        myAnimator.SetFloat("moveX", direction.x);
        myAnimator.SetFloat("moveY", direction.y);
    }

    // Change enemy's state if not already in the state
    private void ChangeState(EnemyState newState)
    {
        if (currentState != newState) 
        {
            currentState = newState;
        }
    }
}