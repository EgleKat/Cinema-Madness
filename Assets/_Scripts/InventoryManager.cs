using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{

    private int inventorySpace = 2;
    //TODO change GameObject to Item
    private GameObject[] inventory;
    private InventoryText inventoryText;

    // Use this for initialization
    void Awake()
    {
        inventory = new GameObject[inventorySpace];
        inventoryText = GameObject.FindGameObjectWithTag("InventoryText").GetComponent<InventoryText>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public bool HasItemWithTag(string tag)
    {
        for (int i = 0; i < inventory.Length; i++)
        {
            if (inventory[i] != null)
            {
                if (inventory[i].CompareTag(tag))
                {
                    return true;
                }
            }
        }
        return false;
    }

    /// <summary>
    /// Add an item to an inventory
    /// </summary>
    /// <param name="item"></param>
    public void AddItemToInventory(GameObject item)
    {
        for (int i = 0; i < inventory.Length; i++)
        {
            if (inventory[i] == null)
            {
                Debug.Log("Adding item to inventory");
                inventory[i] = item;
                inventoryText.SetText(inventory);
                return;
            }
        }
    }

    /// <summary>
    /// Remove a specific item from the inventory
    /// </summary>
    public void RemoveItem(string tag)
    {
        for (int i = 0; i < inventory.Length; i++)
        {
            if (inventory[i] != null && inventory[i].tag == tag)
            {
                inventory[i] = null;
                inventoryText.SetText(inventory);

                return;
            }
        }
    }


    public bool HasSpace()
    {
        for (int i = 0; i < inventory.Length; i++)
        {
            if (inventory[i] == null)
            {
                return true;
            }
        }
        return false;
    }
}
