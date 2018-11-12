using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInventoryItem
{
    Item GetItemData { get; }

    void OnPickup();
}
