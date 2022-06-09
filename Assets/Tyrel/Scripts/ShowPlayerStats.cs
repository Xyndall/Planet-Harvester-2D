using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ShowPlayerStats : MonoBehaviour
{
    public TextMeshProUGUI _drillsOwned;
    public ResourceManager _resources;

    // Start is called before the first frame update
    void Start()
    {
        _drillsOwned.GetComponent<TextMeshProUGUI>();
        _resources.GetComponent<ResourceManager>();
    }

    // Update is called once per frame
    void Update()
    {
        _drillsOwned.text = "Drills Owned  " + _resources._drillsOwned;
    }
}
