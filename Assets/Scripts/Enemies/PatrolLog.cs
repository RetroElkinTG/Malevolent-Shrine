using UnityEngine;

// Patrol Log behaviour
public class PatrolLog : Log
{
    [Header("Patrol Log Variables")]
    public Transform[] path;
    public int currentPoint;
    public Transform currentGoal;
    public float roundingDistance;

    // Check distance to player
    public override void CheckDistance()
    {
        if (Vector2.Distance(targetPosition.position, transform.position) <= chaseRadius &&
            Vector2.Distance(targetPosition.position, transform.position) > attackRadius)
        {
            if (currentState == EnemyState.idle || currentState == EnemyState.walk
                && currentState != EnemyState.stagger)
            {
                MoveTowardsPlayer();
            }
        }
        else if (Vector2.Distance(targetPosition.position, transform.position) > chaseRadius)
        {
            if (Vector3.Distance(transform.position, path[currentPoint].position) > roundingDistance)
            { 
                MoveTowardsGoal();
            }
            else
            {
                ChangeGoal();
            }
        }
    }

    // Move towards goal
    private void MoveTowardsGoal()
    {
        Vector3 targetDirection = Vector2.MoveTowards(transform.position, path[currentPoint].position,
                    enemyMovementSpeed * Time.deltaTime);
        UpdateAnimation(targetDirection - transform.position);
        myRigidbody.MovePosition(targetDirection);
    }

    // Change goal
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