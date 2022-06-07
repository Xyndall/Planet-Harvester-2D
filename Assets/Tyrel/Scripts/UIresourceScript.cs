using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class UIresourceScript : MonoBehaviour
{
    public ResourceManager _resourceManager;

    TextMeshProUGUI _textElement;

    private void Start() 
    {
        _textElement = GetComponent<TextMeshProUGUI>();
    }


    private void Update() 
    {

        _textElement.text = "Resources: " + _resourceManager._resources;
    } 


       

}
