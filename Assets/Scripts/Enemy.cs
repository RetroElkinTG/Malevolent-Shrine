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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}