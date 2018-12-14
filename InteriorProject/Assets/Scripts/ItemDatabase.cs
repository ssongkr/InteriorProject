using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour {

    public List<Item> items = new List<Item>();
	// Use this for initialization
	void Start ()
    {
        // items.Add(new Item(이미지 이름,이름, 아이템아이디, 설명));
        items.Add(new Item("sand", "sand", 1001, "흙"));
        items.Add(new Item("brick", "brick", 1002, "벽돌"));
        

    }

    // Update is called once per frame
    void Update () {
		
	}
}
