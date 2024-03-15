using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Behaviour for breakable objects
public class Breakable : MonoBehaviour
{
    private Animator objectAnimator;

    // Start with getting object components
    void Start()
    {
        objectAnimator = GetComponent<Animator>();
    }

    // Break the object
    public void Break() 
    {
        objectAnimator.SetBool("broken", true);
        StartCoroutine(BreakCo());
    }

    // Remove object collision
    IEnumerator BreakCo() 
    {
        yield return new WaitForSeconds(.3f);
        gameObject.SetActive(false);
    }
}