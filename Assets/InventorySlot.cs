using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    [SerializeField]
    Inventory inventory;

    public Image icon;
    public Button RemoveButton;

    public List<Item> items = new List<Item>();

    public void AddItem(Item newItem)
    {
        items.Add(newItem);
        icon.sprite = items[0].itemIcon;
        icon.enabled = true;

        RemoveButton.interactable = true;
    }

    public void UpdateSlot()
    {

    }

    public void ClearSlot()
    {
        items.Clear();

        icon.sprite = null;
        icon.enabled = false;

        RemoveButton.interactable = false;
    }

    public void OnRemoveButton()
    {
        inventory.RemoveItem(items[0], items.Count);
    }
}
