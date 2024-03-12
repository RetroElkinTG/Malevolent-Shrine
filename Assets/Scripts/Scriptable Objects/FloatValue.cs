using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Float value behaviour
[CreateAssetMenu]
public class FloatValue : ScriptableObject, ISerializationCallbackReceiver
{
    public float initialValue;
    [HideInInspector]
    public float runtimeValue;

    // Load float values into memory before running the entire program
    public void OnBeforeSerialize() 
    { 

    }

    // Load float values into memory before running the entire program
    public void OnAfterDeserialize() 
    {
        runtimeValue = initialValue;
    }
}