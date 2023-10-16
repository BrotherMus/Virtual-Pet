using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerInventory : MonoBehaviour
{
    public static PlayerInventory instance;


    public List<ShopItem> items = new List<ShopItem>();
    public int currency;
    public TextMeshProUGUI textCurrency;
    //display inventory
    public GameObject itemPrefab;
    public Transform itemParent;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddItem(ShopItem item)
    {
        items.Add(item);
        UpdateInventoryDisplay(items);
    }

    public void RemoveItem(ShopItem item)
    {
        items.Remove(item);
    }

    public void AddCurrency(int amount)
    {
        currency += amount;

    }

    //to display coin balance
    private void Update()
    {
        textCurrency.text = currency + "$";
    }

    public void RemoveCurrency(int amount)
    {
        currency -= amount;
    }

    public void UpdateInventoryDisplay(List<ShopItem> items)
    {
        // First, remove all existing items from the UI
        foreach (Transform child in itemParent)
        {
            Destroy(child.gameObject);
        }

        // Then, create a new UI element for each item in the inventory
        foreach (ShopItem item in items)
        {
            //instantiate = spawn
            GameObject newItem = Instantiate(itemPrefab, itemParent);
            newItem.GetComponent<ShopItem>().SetItem(item);
        }
    }
}