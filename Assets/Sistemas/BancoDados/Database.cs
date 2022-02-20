using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using UnityEngine;

[XmlRoot("ItemData")]
public class Database
{
    [XmlArray("Items"), XmlArrayItem("Item")]
    public List<Item> allItems = new List<Item>();

    public static Database instance;

    private void Awake()
    {instance = this;}

    public static Database databaseLoad_items(string path)
    {
        // Carregar XML...
        TextAsset _xml = Resources.Load<TextAsset>(path);
        // Serializador...
        XmlSerializer serializer = new(typeof(Database));
        // Leitor de texto...
        StringReader reader = new StringReader(_xml.text);
        // Ler e guardar informações...
        Database items = serializer.Deserialize(reader) as Database;
        // Encerrar leitura...
        reader.Close();
        // Colar informações na lista
        return items;
    }
}
