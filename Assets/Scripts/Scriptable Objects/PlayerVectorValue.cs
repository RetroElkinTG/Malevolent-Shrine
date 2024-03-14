using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

// Player Vector value behaviour
[CreateAssetMenu]
public class PlayerVectorValue : ScriptableObject, ISerializationCallbackReceiver
{
    public Vector2 runtimeValue;
    public Vector2 defaultValue;

    public Vector2 runtimeMinPositionValue;
    public Vector2 defaultMinPositionValue;
    public Vector2 runtimeMaxPositionValue;
    public Vector2 defaultMaxPositionValue;

    // Set vector values on program load
    public void OnAfterDeserialize()
    {
        runtimeValue = defaultValue;
        runtimeMinPositionValue = defaultMinPositionValue;
        runtimeMaxPositionValue = defaultMaxPositionValue;
    }

    // Required for above method
    public void OnBeforeSerialize ()
    {

    }
}