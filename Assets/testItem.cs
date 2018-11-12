using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testItem : MonoBehaviour, IInventoryItem
{
    [SerializeField]
    Item _item;

    public Item GetItemData
    {
        get
        {
            return _item;
        }
    }

    public void OnPickup()
    {
        gameObject.SetActive(false);
    }
}
