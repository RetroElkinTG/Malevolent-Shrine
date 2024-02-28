using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState
{ 
    idle,
    walk,
    attack,
    stagger,
}

public class Enemy : MonoBehaviour
{
    public EnemyState currentState;
    public int enemyHealth;
    public string enemyName;
    public int enemyBaseDamage;
    public float enemyMovementSpeed;

    public void Knockback(Rigidbody2D myRigidbody, float knockbackTime)
    { 
        StartCoroutine(KnockbackTimeCo(myRigidbody, knockbackTime));
    }

    // Stop knockback after a specified amount of time
    private IEnumerator KnockbackTimeCo(Rigidbody2D myRigidbody, float knockbackTime)
    {
        if (myRigidbody != null)
        {
            yield return new WaitForSeconds(knockbackTime);
            myRigidbody.velocity = Vector2.zero;
            currentState = EnemyState.idle;
        }
    }
}