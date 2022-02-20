using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryTab : MonoBehaviour
{
    public bool     allowInventoryTabAcess;
    public bool     allowInventoryTabToMove;
    public bool     open;
    public Animator animator;
    public InventorySlot template_slot;
    public GameObject inventoryWindow;
    public int maxSlotsAllowed;
    public Vector2 originalPosition;

    public List<Item> playerCurrentItems = new List<Item>();

    public static InventoryTab instance;

    public void Awake()
    {instance = this;}

    public void Start()
    {
        Physics.queriesHitTriggers = true;
        originalPosition = this.transform.position;
    }

    public void Update()
    {ReallocateTabPosition();}

    public void RefreshPlayerInventory()
    {
        // PRIMEIRO, DELETAR PAINÉIS JÁ EXISTENTES...
        try
        {
            foreach (InventorySlot oldSlot in FindObjectsOfType<InventorySlot>())
            {Destroy(oldSlot.gameObject);}
        }

        catch
        {
            Debug.Log("Not able to delete any inventory slot. Prolly there´s not any...");
        }

        // DEPOIS, CRIAR UM PAINEL PARA CADA ITEM DO JOGADOR...
        playerCurrentItems.Capacity = maxSlotsAllowed;

        foreach(Item item in playerCurrentItems)
        {
            InventorySlot slot = template_slot;
            slot.item = item;
            slot.RefreshSlot();
            Instantiate(slot.gameObject, inventoryWindow.transform);
            slot.transform.SetAsLastSibling();
        }
    }
    public void OpenTab()
    {
        open = !open;
        if (allowInventoryTabAcess) animator.SetBool("open", open);
        CameraMovimentacao.instance.CursorOn = open;
    }

    public void OnMouseOver()
    {
        Debug.Log("Over");
    }

    public void ReallocateTabPosition()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.transform != null && hit.transform.CompareTag("InventoryTab") && allowInventoryTabAcess && allowInventoryTabToMove)
            {transform.position = hit.transform.position;}
        }
    }
    public void TabPositionReset()
    {this.transform.position = originalPosition;}
}
