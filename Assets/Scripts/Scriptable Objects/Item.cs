using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Item values
[CreateAssetMenu]
public class Item : ScriptableObject
{
    public Sprite itemSprite;
    public string itemDescription;
    public bool isKey;
}