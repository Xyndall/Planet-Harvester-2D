using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonInfo : MonoBehaviour
{
    public int PerkID;
    public TextMeshProUGUI PriceTXT;
    //public TextMeshProUGUI QuantityTXT;
    public GameObject ShopAI;

    // Update is called once per frame
    void Start()
    {
        PriceTXT.text = "$ " + ShopAI.GetComponent<ShopManager>().shopItems[2, PerkID].ToString();
        //QuantityTXT.text = "Price: $" + ShopAI.GetComponent<ShopManager>().shopItems[3, PerkID].ToString();
    }
}
