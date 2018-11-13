using System;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<List<Item>> items = new List<List<Item>>();

    private const int slots = 50; 

    public event Action<Item> AddUI;
    public event Action<Item, int> RemoveUI;

    public void AddItem(Item item)
    {
        bool notExist = true;
        for (int i = 0; i < items.Count; i++)
        {
            if(items[i].Contains(item))
            {
                items[i].Add(item);
                notExist = false;
            }
        }
        if(items.Count < slots && notExist)
        {
            items.Add(new List<Item>());
            items[items.Count -1].Add(item);
        }
        AddUI(item);
    }

    public void RemoveItem(Item item, int amount)
    {
        for (int i = 0; i < items.Count; i++)
        {
            if(items[i].Contains(item))
            {
                for (int j = 0; j < amount; j++)
                {
                    items[i].RemoveAt(items[i].Count - 1);
                    if (items[i].Count <= 0)
                    {
                        items.RemoveAt(i);
                        RemoveUI(item, amount);
                        break;
                    }
                }
                break;
            }
        }
    }
}
