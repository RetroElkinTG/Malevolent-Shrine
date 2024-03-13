using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Float value behaviour
[CreateAssetMenu]
public class FloatValue : ScriptableObject, ISerializationCallbackReceiver
{
    [HideInInspector]
    public float runtimeValue;
    public float defaultValue;

    // Load float values into memory before running the entire program
    public void OnAfterDeserialize()
    {
        runtimeValue = defaultValue;
    }

    // Load float values into memory before running the entire program
    public void OnBeforeSerialize() 
    { 

    }
}