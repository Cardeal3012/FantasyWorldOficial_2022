using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using UnityEngine;

[System.Serializable]
public class Item
{
    [XmlElement("ID")]
    public string      id;
    [XmlIgnore]
    public string     type;
    [XmlElement("Nome")]
    public string   title;
    [XmlElement("Descricao")]
    public string   description;
    // ---
}
