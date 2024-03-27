using UnityEngine;

// Log behaviour
public class Log : EnemyManager
{
    [Header("Log Movement Variables")]
    public Rigidbody2D myRigidbody;
    public Transform homePosition;
    public Transform targetPosition;
    public float chaseRadius;
    public float attackRadius;

    [Header("Log Animation Variables")]
    public Animator myAnimator;

    // Get components
    void Start()
    {
        currentState = EnemyState.idle;
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        targetPosition = GameObject.FindWithTag("Player").transform;
        myAnimator.SetBool("wakeUp", true);
    }

    // CheckDistance once per physics frame
    void FixedUpdate()
    {
        CheckDistance();
    }

    // Check distance to Player
    public virtual void CheckDistance()
    {
        if (Vector2.Distance(targetPosition.position, transform.position) <= chaseRadius &&
            Vector2.Distance(targetPosition.position, transform.position) > attackRadius)
        {
            if (currentState == EnemyState.idle || currentState == EnemyState.walk
                && currentState != EnemyState.stagger)
            {
                MoveTowardsPlayer();
                UpdateState(EnemyState.walk);
            }
        }
        else if (Vector2.Distance(targetPosition.position, transform.position) > chaseRadius)
        {
            myAnimator.SetBool("wakeUp", false);
        }
    }

    // Move towards Player
    public virtual void MoveTowardsPlayer()
    {
        Vector3 targetDirection = Vector2.MoveTowards(transform.position, targetPosition.position,
                    enemyMovementSpeed * Time.deltaTime);
        UpdateAnimation(targetDirection - transform.position);
        myRigidbody.MovePosition(targetDirection);
        myAnimator.SetBool("wakeUp", true);
    }

    // Update state
    private void UpdateState(EnemyState newState)
    {
        if (currentState != newState)
        {
            currentState = newState;
        }
    }

    // Update animation
    public void UpdateAnimation(Vector2 direction)
    { 
        direction = direction.normalized;
        myAnimator.SetFloat("moveX", direction.x);
        myAnimator.SetFloat("moveY", direction.y);
    }
}