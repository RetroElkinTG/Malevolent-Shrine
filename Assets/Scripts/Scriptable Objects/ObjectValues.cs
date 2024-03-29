using UnityEngine;

// Object values
[CreateAssetMenu]
public class ObjectValues : ScriptableObject, ISerializationCallbackReceiver
{
    [Header("Object Variables")]
    [HideInInspector]
    public bool runtimeChestIsOpen;
    public bool defaultChestIsOpen;
    [HideInInspector]
    public bool runtimeDoorIsOpen;
    public bool defaultDoorIsOpen;
    [HideInInspector]
    public bool runtimeHeartIsPickedUp;
    public bool defaultHeartIsPickedUp;

    // Load game values pre-runtime
    public void OnAfterDeserialize()
    {
        runtimeChestIsOpen = defaultChestIsOpen;
        runtimeDoorIsOpen = defaultDoorIsOpen;
        runtimeHeartIsPickedUp = defaultHeartIsPickedUp;
    }

    // Required for above method
    public void OnBeforeSerialize()
    {

    }
}
