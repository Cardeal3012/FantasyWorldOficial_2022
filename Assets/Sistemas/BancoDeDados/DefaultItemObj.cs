using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Default Object", menuName = "Inventory System/Items/Default")]
public class DefaultItemObj : ItemObj
{
    private void Awake()
    {
        type = itemType.Other;
    }
}
