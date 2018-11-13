using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public Inventory inventory;

    Transform inventoryPanel;

    InventorySlot[] slots;

    void Start()
    {
        inventoryPanel = transform.Find("InventoryPanel");

        inventory.AddUI += AddUI;
        inventory.RemoveUI += RemoveUI;

        slots = inventoryPanel.GetComponentsInChildren<InventorySlot>();
    }

    void AddUI(Item item)
    {
        bool notExist = true;
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].items.Contains(item))
            {
                slots[i].AddItem(item);
                notExist = false;

                break;
            }
        }
        if (notExist)
        {
            for (int i = 0; i < slots.Length; i++)
            {
                if(slots[i].items.Count <= 0)
                {
                    slots[i].AddItem(item);

                    break;
                }
            }
        }
    }

    void RemoveUI(Item item, int amount)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].items.Contains(item))
            {
                for (int j = 0; j < amount; j++)
                {
                    slots[i].items.RemoveAt(slots[i].items.Count - 1);
                    if (slots[i].items.Count <= 0)
                    {
                        slots[i].ClearSlot();
                    }
                }
                if (slots[i].items.Count > 0)
                {
                    slots[i].UpdateSlot();
                }
                break;
            }
        }
    }
}
