using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopItem : MonoBehaviour
{
        public string itemName;
        public int itemPrice;
        public string itemDescription;

    public void SetItem(ShopItem item)
    {
        item.itemName = itemName;
        item.itemPrice = itemPrice;
        item.itemDescription = itemDescription;
    }

    public void RemoveItem()
    {
        Destroy(gameObject);
    }

}
