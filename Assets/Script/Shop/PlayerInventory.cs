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

    public List<GameObject> prefab = new List<GameObject>();

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

    public void AddItemChicken(ShopItem item)
    {
        items.Add(item);
        UpdateInventoryDisplayChicken(items);
    }

    public void AddItemOctopus(ShopItem item)
    {
        items.Add(item);
        UpdateInventoryDisplayOctopus(items);
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
       

        // Then, create a new UI element for each item in the inventory
        
            //instantiate = spawn
            GameObject newItem = Instantiate(prefab[0], itemParent);
            //newItem.GetComponent<ShopItem>().SetItem(item);
        
    }

    public void UpdateInventoryDisplayChicken(List<ShopItem> items)
    {
              

        // Then, create a new UI element for each item in the inventory
        
            //instantiate = spawn
            GameObject newItem = Instantiate(prefab[1], itemParent);
            //newItem.GetComponent<ShopItem>().SetItem(item);
        
    }

    public void UpdateInventoryDisplayOctopus(List<ShopItem> items)
    {
        

        // Then, create a new UI element for each item in the inventory
        
            //instantiate = spawn
            GameObject newItem = Instantiate(prefab[2], itemParent);
            //newItem.GetComponent<ShopItem>().SetItem(item);
        
    }
}