using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {
    public List<Item> inventory = new List<Item>();
    public Transform Character;
    // 인벤토리 리스트
    private ItemDatabase db;
    // 아이템 데이터베이스 추가는 직접

    public int slotX;    // 인벤토리 가로 변수
    public List<Item> slots = new List<Item>(); // 인벤토리 속성 변수

    private bool showInventory = false;
    // I버튼을 누르면 활성화/비활성화 되는 부울 변수
    public GUISkin skin;

    private string tooltip;
    // 툴팁 추가를 위한 부울 변수와 스트링 변수

    private Item nowitem;
    //현재 아이템

    // Use this for initialization
    void Start () {
        for (int i = 0; i < slotX; i++)
        {
            slots.Add(new Item());
            // 아이템 슬롯칸에 빈 오브젝트 추가하기
            inventory.Add(new Item());
            // 인벤토리에 추가
        }
        db = GameObject.FindGameObjectWithTag("Item Database").GetComponent<ItemDatabase>();

        for (int i = 0; i < db.items.Count; i++)
        {
            if (db.items[i] != null)
            {
                inventory[i] = db.items[i];
                // 디비의 아이템칸에 비어있지 않다면, 저장
            }
            else
                break;
        }
        // 인벤토리에 db에 저장되어있는 0번째 아이템을 가져옴

        /* for(int i=0; i<n; i++) {
         *      inventory.Add(db.items[i]);
         * }
         */
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetButtonDown("Inventory"))
        {
            showInventory = !showInventory;
        }
    }

    void OnGUI()
    {
        GUI.skin = skin;
        if (showInventory)
        {
            DrawInventory();   
        }

        DrawNowItem();
    }

    void DrawInventory()
    {
        int k = 0;
        Event e = Event.current;
        for (int i = 0; i < slotX; i++)
        {
            
            Rect slotRect = new Rect(i * 52 + 100, 0, 50, 50);
            // 박스 분할하기
            GUI.Box(slotRect, "", skin.GetStyle("slot background"));
                
            // 기능 추가하기
            slots[k] = inventory[k];
            if (slots[k].itemName != null)
            {
                GUI.DrawTexture(slotRect, slots[k].itemIcon);
                if (slotRect.Contains(e.mousePosition))
                // 만약 마우스가 해당 인벤토리 창-버튼-위로 올라온다면,
                {
                    tooltip = CreateTooltip(slots[k]);
                    GUI.Box(new Rect(slotRect.x + 5, slotRect.y + 50, 200, 200), tooltip, skin.GetStyle("tooltip"));
                    if (e.isMouse && e.type == EventType.MouseDown && e.button == 0)
                    {
                        nowitem = slots[k];
                    }
                }
                
            }

            k++;
            // 갯수 증가
            
        }
    }
    string CreateTooltip(Item item)
    {
        tooltip = "Item name:" + item.itemName;
        /* html 태그가 어느정도 먹힘
         * <color=#000000> 말 </color>
         * <b> 두껍게 </b>
         * ... emdemdemd
         */

        return tooltip;
    }
    

    void DrawNowItem()
    {
        Rect itemRect = new Rect(320, 320, 50, 50);
        // 박스 분할하기
        GUI.Box(itemRect, "", skin.GetStyle("slot background"));
        if(nowitem!=null)
            GUI.DrawTexture(itemRect, nowitem.itemIcon);
    }

    public Item GetItem()
    {
        if (nowitem != null)
        {
            return nowitem;
        }
        else
            return null;
    }
    public void SetItem(Item item)
    {
         nowitem=item;
    }

    void AddItem(int id)
    // 본 함수에서 id를 받아서
    {
        for (int i = 0; i < inventory.Count; i++)
        {

            if (inventory[i].itemName == null)
            // 인벤토리가 빈자리면 
            {
                for (int j = 0; j < db.items.Count; j++)
                // 추가한 값까지 모두 찾은 다음에
                {
                    if (db.items[j].itemId == id)
                    {
                        // 디비의 아이템의 ID와 입력한 ID가 같다면,
                        inventory[i] = db.items[j];
                        // 빈 인벤토리에 db에 저장된 아이템을 적용하고
                        return;
                    }
                }
            }
        }
    }

    bool inventoryContains(int id)
    {
        for (int i = 0; i < inventory.Count; i++)
        {
            return (inventory[i].itemId == id);
        }
        return false;
    }

    void RemoveItem(int id)
    {
        for (int i = 0; i < inventory.Count; i++)
        {
            if (inventory[i].itemId == id)
            {
                inventory[i] = new Item();
                break;
            }
        }
    }
}
