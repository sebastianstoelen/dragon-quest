﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemUIElement : MonoBehaviour
{
    public Image buttonImage;
    public Text itemAmount;
    public int itemId;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelectItem()
    {
        if (GameManager.instance.playerInventory.HasItemAt(itemId))
        {
            string itemName = GameManager.instance.playerInventory.GetItemNameAt(itemId);
            GameMenu.instance.SetActiveItem(GameManager.instance.GetReferenceItemDetails(itemName), itemName);
        }
    }
}
