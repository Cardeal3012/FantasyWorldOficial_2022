using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // CONTROLE DE BANCO DE DADOS
    #region
    [SerializeField]
    private const string datapath = "Data/data_items";

    private void Start()
    {
        Database_itemsLoad();
    }

    void  Database_itemsLoad()
    {
        // PROCURAR BANCO DE DADOS
        Database data_items = Database.databaseLoad_items(datapath);
        // LER, INTERPRETAR E ARMAZENAR OS DADOS
        foreach(Item item in data_items.allItems)
        {
            // Criar nova instância de item
            Item neoItem = new Item();
            // Repassar informações e cobrir variáveis
            neoItem.id    = item.id;
            neoItem.type  = "0";
            neoItem.title = item.title;
            neoItem.description = item.description;
            Debug.Log(neoItem.title);
        }

            Debug.Log("Database Loaded!");
            // TESTE DOS SLOTS NO INVENTARIO
            InventoryTab.instance.RefreshPlayerInventory();
    }
    #endregion
}
