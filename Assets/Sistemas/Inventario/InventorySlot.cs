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

    /// Legenda vari�vel type:
    /// [0] = qualquer
    /// [1] = consumivel / p�e no cinto
    /// [2] = arma / m�o dir, m�o esq
    /// [3] = capacete / cabe�a
    /// [4] = armadura / torso
    /// [5] = cal�a / pernas
    /// [6] = botas / p�
    
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
