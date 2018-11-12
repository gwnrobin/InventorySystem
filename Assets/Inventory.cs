using System;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private Dictionary<string, List<Item>> _items = new Dictionary<string, List<Item>>();

    private const int slots = 50; 

    public event Action<Item> ItemAdded;
    public event Action<string> ItemRemove;

    public void AddItem(IInventoryItem item)
    {
        if (_items.ContainsKey(item.GetItemData.itemName) && item.GetItemData.stackable)
        {
            _items[item.GetItemData.itemName].Add(item.GetItemData);
        }
        else if (_items.Count <= slots)
        {
            _items.Add(item.GetItemData.itemName, new List<Item>());
            _items[item.GetItemData.itemName].Add(item.GetItemData);
            ItemAdded(item.GetItemData);
            item.OnPickup();
        }
    }
	
    public void RemoveItem(string type)
    {
        ItemRemove(type);
        if(_items[type].Count <= 0)
        {
            _items.Remove(type);
        }
        else
        {
            _items[type].RemoveAt(_items[type].Count);
        }
    }

    public Item GetItem(string type)
    {
        if (!_items.ContainsKey(type))
        {
            return null;
        }

        return _items[type][0];
    }
}
