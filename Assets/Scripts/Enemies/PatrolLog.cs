using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolLog : Log
{
    public Transform[] path;
    public int currentPoint;
    public Transform currentGoal;
    public float roundingDistance;

    // Check distance between enemy and player then move towards player
    public override void CheckDistance()
    {
        if (Vector2.Distance(targetPosition.position, transform.position) <= chaseRadius &&
            Vector2.Distance(targetPosition.position, transform.position) > attackRadius)
        {
            if (currentState == EnemyState.idle || currentState == EnemyState.walk
                && currentState != EnemyState.stagger)
            {
                Vector3 targetDirection = Vector2.MoveTowards(transform.position, targetPosition.position,
                    enemyMovementSpeed * Time.deltaTime);
                UpdateAnimation(targetDirection - transform.position);
                myRigidbody.MovePosition(targetDirection);
                //ChangeState(EnemyState.walk);
                myAnimator.SetBool("wakeUp", true);
            }
        }
        else if (Vector2.Distance(targetPosition.position, transform.position) > chaseRadius)
        {
            if (Vector3.Distance(transform.position, path[currentPoint].position) > roundingDistance)
            { 
                Vector3 targetDirection = Vector2.MoveTowards(transform.position, path[currentPoint].position,
                    enemyMovementSpeed * Time.deltaTime);
                UpdateAnimation(targetDirection - transform.position);
                myRigidbody.MovePosition(targetDirection);
            }
            else
            {
                ChangeGoal();
            }
        }
    }

    // Change enemy goal
    private void ChangeGoal()
    {
        if (currentPoint == path.Length - 1)
        {
            currentPoint = 0;
            currentGoal = path[0];
        }
        else
        {
            currentPoint++;
            currentGoal = path[currentPoint];
        }
    }
}