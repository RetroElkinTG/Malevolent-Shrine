using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Inventory values
[CreateAssetMenu]
public class Inventory : ScriptableObject
{
    public Item currentItem;
    public List<Item> items = new List<Item>();
    public int keyCount;
}