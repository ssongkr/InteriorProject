using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]


public class Item
{
    public string itemName;
    public int itemId;
    public Texture2D itemIcon;
    public string itemDes;          // 아이템의 설명

    public Item()
    {

    }

    public Item(string img, string name, int id, string des)
    // 아이템의 필요한 속성
    {
        itemName = name;
        itemId = id;
        // itemIcon 속성은 별도의 방법
        itemIcon = Resources.Load<Texture2D>("ItemIcons/" + img);

        itemDes = des;
    }
}
