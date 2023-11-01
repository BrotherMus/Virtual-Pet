using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public List<ShopItem> itemsForSale = new List<ShopItem>();


    public void BuyItem(ShopItem item)
    {
        if (PlayerInventory.instance.currency >= item.itemPrice)
        {
            PlayerInventory.instance.AddItem(item);
            PlayerInventory.instance.RemoveCurrency(item.itemPrice); }
        else
        {
            Debug.Log("Not enough currency to buy this item.");
        }
    }

    public void BuyItemChicken(ShopItem item)
    {
        if (PlayerInventory.instance.currency >= item.itemPrice)
        {
            PlayerInventory.instance.AddItemChicken(item);
            PlayerInventory.instance.RemoveCurrency(item.itemPrice);
        }
        else
        {
            Debug.Log("Not enough currency to buy this item.");
        }
    }

    public void BuyItemOctopus(ShopItem item)
    {
        if (PlayerInventory.instance.currency >= item.itemPrice)
        {
            PlayerInventory.instance.AddItemOctopus(item);
            PlayerInventory.instance.RemoveCurrency(item.itemPrice);
        }
        else
        {
            Debug.Log("Not enough currency to buy this item.");
        }
    }


}
