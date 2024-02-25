using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    public float knockback;
    public float knockbackTime;

    // Knockback entity when hit
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Player"))
        { 
            Rigidbody2D entity = collision.GetComponent<Rigidbody2D>();
            if (entity != null) 
            { 
                entity.isKinematic = false;
                Vector2 vector = entity.transform.position - transform.position;
                vector = vector.normalized * knockback;
                entity.AddForce(vector, ForceMode2D.Impulse);
                StartCoroutine(KnockbackTimeCo(entity));
            }
        }
    }

    // Knockback enemy until specified amount of time
    private IEnumerator KnockbackTimeCo(Rigidbody2D entity) 
    {
        if (entity != null) 
        { 
            yield return new WaitForSeconds(knockbackTime);
            entity.velocity = Vector2.zero;
            entity.isKinematic = true;
        }
    }
}