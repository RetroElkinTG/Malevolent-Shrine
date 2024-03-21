using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

// Scene transition values
[CreateAssetMenu]
public class TransitionValues : ScriptableObject, ISerializationCallbackReceiver
{
    [HideInInspector]
    public Vector2 runtimePlayerPosition;
    public Vector2 defaultPlayerPosition;
    [HideInInspector]
    public Vector2 runtimeCameraMinPosition;
    public Vector2 defaultCameraMinPosition;
    [HideInInspector]
    public Vector2 runtimeCameraMaxPosition;
    public Vector2 defaultCameraMaxPosition;

    // Load values pre-runtime
    public void OnAfterDeserialize()
    { 
        runtimePlayerPosition = defaultPlayerPosition;
        runtimeCameraMinPosition = defaultCameraMinPosition;
        runtimeCameraMaxPosition = defaultCameraMaxPosition;
    }

    // Required for above method
    public void OnBeforeSerialize ()
    {

    }
}