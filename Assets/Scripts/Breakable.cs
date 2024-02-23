using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakable : MonoBehaviour
{
    private Animator objectAnimator;

    // Start with getting object components
    void Start()
    {
        objectAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
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