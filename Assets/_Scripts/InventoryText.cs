using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryText : MonoBehaviour
{
    private Text text;

    private void Awake()
    {
        text = GetComponent<Text>();
    }
    public void SetText(GameObject[] inventory)
    {

        string newText = "";


        foreach (GameObject item in inventory)
        {
            if (item != null)
            {
                newText += item.tag + "\n";
            }
        }
        text.text = newText;
    }

}
