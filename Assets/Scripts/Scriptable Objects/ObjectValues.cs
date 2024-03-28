using UnityEngine;

// Object values
[CreateAssetMenu]
public class ObjectValues : ScriptableObject, ISerializationCallbackReceiver
{
    [Header("Object Variables")]
    [HideInInspector]
    public bool runtimeChestIsOpen;
    public bool defaultChestIsOpen;

    // Load game values pre-runtime
    public void OnAfterDeserialize()
    {
        runtimeChestIsOpen = defaultChestIsOpen;
    }

    // Required for above method
    public void OnBeforeSerialize()
    {

    }
}
