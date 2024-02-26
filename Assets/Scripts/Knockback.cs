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
        if (collision.gameObject.CompareTag("Enemy"))
        { 
            Rigidbody2D myRigidbody = collision.GetComponent<Rigidbody2D>();
            if (myRigidbody != null) 
            {
                myRigidbody.GetComponent<Enemy>().currentState = EnemyState.stagger;
                Vector2 differenceVector = myRigidbody.transform.position - transform.position;
                differenceVector = differenceVector.normalized * knockback;
                myRigidbody.AddForce(differenceVector, ForceMode2D.Impulse);
                StartCoroutine(KnockbackTimeCo(myRigidbody));
            }
        }
    }

    // Stop knockback after a specified amount of time
    private IEnumerator KnockbackTimeCo(Rigidbody2D myRigidbody) 
    {
        if (myRigidbody != null) 
        { 
            yield return new WaitForSeconds(knockbackTime);
            myRigidbody.velocity = Vector2.zero;
            myRigidbody.GetComponent<Enemy>().currentState = EnemyState.idle;
        }
    }
}