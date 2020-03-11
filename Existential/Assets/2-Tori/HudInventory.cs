﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class HudInventory : MonoBehaviour
{
    public Inventory Inventory;

    // Start is called before the first frame update
    void Start(){
        Inventory.ItemAdded += Inventory_ItemAdded;
    }

    private void Inventory_ItemAdded(object sender, InventoryEventArgs e){
        Transform inventoryPanel = transform.Find("Invenory");
        foreach(Transform slot in inventoryPanel)
        {
            Image image = slot.GetChild(0).GetComponent<Image>();

            if (!image.enabled)
            {
                image.enabled = true;
                image.sprite = e.Item.Image;
                break;
            }
        }
    }
    // Update is called once per frame
    void Update(){
        
    }
}
