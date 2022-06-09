using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class ShopManager : MonoBehaviour
{
    public int[,] shopItems = new int[5, 5];
    public float Resources;
    public TextMeshProUGUI ResourceTXT;

    // Start is called before the first frame update
    void Start()
    {
        ResourceTXT.text = "Resources:" + Resources.ToString();

        //ID
        shopItems[1, 1] = 1;
        shopItems[1, 2] = 2;
        shopItems[1, 3] = 3;
        shopItems[1, 4] = 4;

        //Price
        shopItems[2, 1] = 150;
        shopItems[2, 2] = 200;
        shopItems[2, 3] = 250;
        shopItems[2, 4] = 300;

        //Quantity
        //shopItems[3, 1] = 150;
        //shopItems[3, 2] = 200;
        //shopItems[3, 3] = 250;
        //shopItems[3, 4] = 300;
    }

    // Update is called once per frame
    public void Buy()
    {
        GameObject ButtonRef = GameObject.FindGameObjectWithTag("Shop").GetComponent<EventSystem>().currentSelectedGameObject;

        if (Resources >= shopItems[2, ButtonRef.GetComponent<ButtonInfo>().PerkID])
        {
            Resources -= shopItems[2, ButtonRef.GetComponent<ButtonInfo>().PerkID];
            shopItems[3, ButtonRef.GetComponent<ButtonInfo>().PerkID]++;
            ResourceTXT.text = "Money:" + Resources.ToString();
            //ButtonRef.GetComponent<ButtonInfo>().QuantityTXT.text = shopItems[3, ButtonRef.GetComponent<ButtonInfo>().PerkID].ToString();

        }
    }
}
