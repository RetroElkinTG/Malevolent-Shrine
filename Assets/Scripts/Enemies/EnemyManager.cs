using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Enemy states
public enum EnemyState
{ 
    idle,
    walk,
    attack,
    stagger,
}

// Enemy behaviour
public class EnemyManager : MonoBehaviour
{
    public EnemyState currentState;
    public HeartValues enemyMaxHealth;
    public float health;
    public string enemyName;
    public int enemyBaseDamage;
    public float enemyMovementSpeed;

    // Set enemy health
    private void Awake()
    {
        health = enemyMaxHealth.runtimeValue;
    }

    // Reduce enemy health
    private void TakeDamage(float damage) 
    {
        health -= damage;
        if (health <= 0)
        { 
            gameObject.SetActive(false);
        }
    }

    // Start knockback coroutine
    public void Knockback(Rigidbody2D myRigidbody, float knockbackTime, float damage)
    { 
        StartCoroutine(KnockbackTimeCo(myRigidbody, knockbackTime));
        TakeDamage(damage);
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