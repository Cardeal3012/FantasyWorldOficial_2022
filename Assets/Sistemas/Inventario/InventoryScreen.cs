using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryScreen : MonoBehaviour{

    public static InventoryScreen instance;
    public        Animator        ani_inventoryScreen;
    public        Image           inventoryRaycast;

    public bool allowedToAcessInventory;
    public bool open;

    void Awake()
    {instance = this;}

    void Update()
    {
        Commands();
    }

    // Comandos
    void Commands()
    {
        if (Input.GetButtonDown("Inventory") && allowedToAcessInventory) open = !open;

        // fechar inventário
        if (!open)
        {
            ani_inventoryScreen.SetBool("Open", false);
            // inventoryRaycast.enabled = true;
            allowedToAcessInventory = true;
            CameraMovimentacao.instance.rotationSpeed = 2;
            CameraMovimentacao.instance.CursorOn      = false;
        }

        // Abrir inventário
        if (open)
        {
            ani_inventoryScreen.SetBool("Open", true);
            // inventoryRaycast.enabled = false;
            allowedToAcessInventory  = true;
            CameraMovimentacao.instance.rotationSpeed = 0;
            CameraMovimentacao.instance.CursorOn      = true;
        }
    }
}
