using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Consumable Object", menuName = "Inventory System/Items/Consumable")]
public class Consumable : ItemObj
{
    private void Awake()
    {
        type = itemType.Consumable;
    }
}
