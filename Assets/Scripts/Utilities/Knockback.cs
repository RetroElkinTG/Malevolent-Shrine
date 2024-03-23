using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Knockback behaviour
public class Knockback : MonoBehaviour
{
    public float knockback;
    public float knockbackTime;
    public float damage;

    // Knockback object on hit
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Breakable") && gameObject.CompareTag("Player"))
        {
            collision.GetComponent<Breakable>().Break();
        }
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Player"))
        { 
            Rigidbody2D collidedRigidbody = collision.GetComponent<Rigidbody2D>();
            if (collidedRigidbody != null)
            {
                Vector2 differenceVector = collidedRigidbody.transform.position - transform.position;
                differenceVector = differenceVector.normalized * knockback;
                collidedRigidbody.AddForce(differenceVector, ForceMode2D.Impulse);
                if (collision.gameObject.CompareTag("Enemy") && collision.isTrigger) 
                {
                    collidedRigidbody.GetComponent<EnemyManager>().currentState = EnemyState.stagger;
                    collision.GetComponent<EnemyManager>().Knockback(collidedRigidbody, knockbackTime, damage);
                }
                if (collision.gameObject.CompareTag("Player")) 
                {
                    if (collision.GetComponent<PlayerManager>().currentState != PlayerState.stagger) 
                    {
                        collidedRigidbody.GetComponent<PlayerManager>().currentState = PlayerState.stagger;
                        collision.GetComponent<PlayerManager>().Knockback(knockbackTime, damage);
                    }
                }
            }
        }
    }
}