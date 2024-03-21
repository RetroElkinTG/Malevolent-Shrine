using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Heart values
[CreateAssetMenu]
public class HealthValues : ScriptableObject, ISerializationCallbackReceiver
{
    [HideInInspector]
    public float runtimeValue;
    public float defaultValue;

    // Load transition values pre-runtime
    public void OnAfterDeserialize()
    {
        runtimeValue = defaultValue;
    }

    // Required for above method
    public void OnBeforeSerialize() 
    { 

    }
}