using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Inventory behaviour
[CreateAssetMenu]
public class Inventory : ScriptableObject, ISerializationCallbackReceiver
{
    public Item currentItem;
    public List<Item> items = new List<Item>();
    [HideInInspector]
    public int runtimeKeyCount;
    public int defaultKeyCount;

    // Load values pre-runtime
    public void OnAfterDeserialize()
    {
        runtimeKeyCount = defaultKeyCount;
    }

    // Required for above method
    public void OnBeforeSerialize()
    {

    }

    // Add item to inventory
    public void AddItem(Item itemToAdd)
    {
        if (itemToAdd.isKey)
        {
            runtimeKeyCount++;
        }
        else
        {
            if (!items.Contains(itemToAdd))
            { 
                items.Add(itemToAdd);
            }
        }
    }
}