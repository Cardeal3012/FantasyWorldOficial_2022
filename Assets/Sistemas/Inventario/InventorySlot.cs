using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour
{
    public Item   item;
    public Image  highlight;
    public Image  itemImage;
    public Sprite itemDefaultIcon;
    public Text   itemQuantity;
    public byte   type;

    /// Legenda variável type:
    /// [0] = qualquer
    /// [1] = consumivel / põe no cinto
    /// [2] = arma / mão dir, mão esq
    /// [3] = capacete / cabeça
    /// [4] = armadura / torso
    /// [5] = calça / pernas
    /// [6] = botas / pé
    
    public void RefreshSlot()
    {
        if (item != null)
        {
            itemImage.sprite = itemDefaultIcon;
        }
    }

    public void Highlight()
    {
        highlight.enabled = true;
    }

    public void Unhighlight()
    {
        highlight.enabled = false;
    }
}
