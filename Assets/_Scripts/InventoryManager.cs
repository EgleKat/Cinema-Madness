using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour {

    public int inventorySpace = 1;
    //TODO change GameObject to Item
    private GameObject[] inventory;

	// Use this for initialization
	void Awake() {
        inventory = new GameObject[inventorySpace];
    }
	
	// Update is called once per frame
	void Update () {
		
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
        for(int i=0; i<inventory.Length; i++)
        {
            if(inventory[i]==null)
            {
                Debug.Log("Adding item to inventory");
                inventory[i] = item;
                return;
            }
        }
    }

    /// <summary>
    /// Remove a specific item from the inventory
    /// </summary>
    /// <param name="itemToRemove"></param>
    public void RemoveItem(string tag)
    {
        for(int i=0; i<inventory.Length; i++)
        {
            if(inventory[i].tag==tag)
            {
                inventory[i] = null;
                return;
            }
        }
    }


    public bool HasSpace()
    {
        for (int i = 0; i < inventory.Length; i++)
        {
            if (inventory[i]== null)
            {
                return true;
            }
        }
        return false;
    }
}
