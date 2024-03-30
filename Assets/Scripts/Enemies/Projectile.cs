using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Header("Projectile Variables")]
    public float speed;
    public Vector2 targetDirection;
    private float runtimeShotDuration;
    public float defaultShotDuration;
    public Rigidbody2D myRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        runtimeShotDuration = defaultShotDuration;
    }

    // Destroy projectile after specific duration
    void Update()
    {
        runtimeShotDuration -= Time.deltaTime;
        if (runtimeShotDuration <= 0)
        {
            Destroy(gameObject);
        }
    }
    
    // Launch projectile
    public void Shoot(Vector2 targetDirection)
    {
        myRigidbody.velocity = targetDirection * speed;
    }

    // Destroy projectile on hit
    public void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}
