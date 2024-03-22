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
    public HealthValues enemyMaxHealth;
    public float health;
    public string enemyName;
    public int enemyBaseDamage;
    public float enemyMovementSpeed;
    public GameObject deathAnimation;

    // Set enemy health
    private void Awake()
    {
        health = enemyMaxHealth.runtimeValue;
    }

    // Knockback object
    public void Knockback(Rigidbody2D myRigidbody, float knockbackTime, float damage)
    {
        StartCoroutine(KnockbackTimeCo(myRigidbody, knockbackTime));
        TakeDamage(damage);
    }

    // Reduce enemy health
    private void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            DeathAnimation();
            gameObject.SetActive(false);
        }
    }

    // Knockback time
    private IEnumerator KnockbackTimeCo(Rigidbody2D myRigidbody, float knockbackTime)
    {
        if (myRigidbody != null)
        {
            yield return new WaitForSeconds(knockbackTime);
            myRigidbody.velocity = Vector2.zero;
            currentState = EnemyState.idle;
        }
    }

    // Death animation
    private void DeathAnimation() 
    {
        if (deathAnimation != null)
        {
            GameObject animation = Instantiate(deathAnimation, transform.position, Quaternion.identity);
            Destroy(animation, 1f);
        }
    }
}