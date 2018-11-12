using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public Inventory inventory;

    Transform inventoryPanel;

    void Start()
    {
        inventoryPanel = transform.Find("InventoryPanel");

        inventory.ItemAdded += AddItemUI;
        inventory.ItemRemove += RemoveItemUI;
    }

    void AddItemUI(Item item)
    {
        foreach(Transform slot in inventoryPanel)
        {
            Image image = slot.GetChild(0).GetChild(0).GetComponent<Image>();
            if (!image.enabled)
            {
                image.enabled = true;
                image.sprite = item.itemIcon;

                break;
            }
        }
    }

    void RemoveItemUI(string type)
    {
        foreach (Transform slot in inventoryPanel)
        {
            Image image = slot.GetChild(0).GetChild(0).GetComponent<Image>();
            if (image.enabled)
            {
                if(image.sprite.name == type)
                {
                    image.sprite = null;
                    image.enabled = false;

                    break;
                }
            }
        }
    }
}
