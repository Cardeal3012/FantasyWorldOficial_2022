using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum itemType
{
    Consumable,
    Weapon,
    Other
}

public abstract class ItemObj : ScriptableObject
{
    public GameObject displayPrefab;
    public itemType type;
    [TextArea(15, 20)]
    public string   description;
    public int      power;
    public int      value;
}
