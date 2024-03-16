using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Inventory behaviour
[CreateAssetMenu]
public class Inventory : ScriptableObject
{
    public Item currentItem;
    public List<Item> items = new List<Item>();
    public int keyCount;

    // Add item to inventory
    public void AddItem(Item itemToAdd)
    {
        if (itemToAdd.isKey)
        {
            keyCount++;
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