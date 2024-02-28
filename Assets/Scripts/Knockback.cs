using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    public float knockback;
    public float knockbackTime;

    // Knockback enemy when hit
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
                if (collision.gameObject.CompareTag("Enemy")) 
                {
                    collidedRigidbody.GetComponent<Enemy>().currentState = EnemyState.stagger;
                    collision.GetComponent<Enemy>().Knockback(collidedRigidbody, knockbackTime);
                }
                if (collision.gameObject.CompareTag("Player")) 
                {
                    collidedRigidbody.GetComponent<PlayerMovement>().currentState = PlayerState.stagger;
                    collision.GetComponent<PlayerMovement>().Knockback(knockbackTime);
                }
            }
        }
    }
}