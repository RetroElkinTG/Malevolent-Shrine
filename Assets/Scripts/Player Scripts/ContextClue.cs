using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Context clue behaviour
public class ContextClue : MonoBehaviour
{
    public GameObject contextClue;

    // Enable context clue
    public void Enable()
    {
        contextClue.SetActive(true);
    }

    // Disable context clue
    public void Disable()
    {
        contextClue.SetActive(false);
    }
}