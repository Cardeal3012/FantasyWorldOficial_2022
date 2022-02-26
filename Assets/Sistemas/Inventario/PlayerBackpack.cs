using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBackpack : MonoBehaviour
{
    public InventoryObject backpack;

    public void OnTriggerEnter(Collider other)
    {
        var item = other.GetComponent<Collectible>();
        if (item)
        {
            backpack.AddItem(item.item, 1);
            Destroy(other.gameObject);
        }
    }

    public void OnApplicationQuit()
    {backpack.Container.Clear();}
}
