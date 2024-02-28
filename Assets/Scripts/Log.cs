using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Log : Enemy
{
    private Rigidbody2D myRigidbody;
    public Transform targetPosition;
    public float chaseRadius;
    public float attackRadius;
    public Transform homePosition;

    // Start is called before the first frame update
    void Start()
    {
        currentState = EnemyState.idle;
        myRigidbody = GetComponent<Rigidbody2D>();
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
            if (currentState == EnemyState.idle || currentState == EnemyState.walk && currentState != EnemyState.stagger) 
            {
                Vector2 targetVector = Vector2.MoveTowards(transform.position, targetPosition.position, enemyMovementSpeed * Time.deltaTime);
                myRigidbody.MovePosition(targetVector);
                ChangeState(EnemyState.walk);
            }
        }
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