using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Log : Enemy
{
    public Transform targetPosition;
    public float chaseRadius;
    public float attackRadius;
    public Transform homePosition;

    // Start is called before the first frame update
    void Start()
    {
        targetPosition = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        CheckDistance();
    }

    // Move towards player if player is close enough
    void CheckDistance()
    { 
        if (Vector3.Distance(targetPosition.position, transform.position) <= chaseRadius && 
            Vector3.Distance(targetPosition.position, transform.position) > attackRadius)
        { 
            transform.position = Vector3.MoveTowards(transform.position, targetPosition.position, enemyMovementSpeed * Time.deltaTime);
        }
    }
}