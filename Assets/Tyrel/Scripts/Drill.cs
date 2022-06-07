using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drill : MonoBehaviour
{

    public ResourceManager _resourceManager;

    public bool _isDrilling;

    public bool _overPlanet;


    public bool _hasDrill;
    public bool IsPlayerOneDrill;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && _overPlanet == true || Input.GetKeyDown(KeyCode.Comma) && _overPlanet == true)
        {
            _isDrilling = true;
            PlaceDrill(_isDrilling);
            Debug.Log("Drilling");
        }

    }

    public void UpdateIsDrilling(bool drillingTrue)
    {
        _isDrilling = drillingTrue;
    }

    public void PlaceDrill(bool IsDrilling)
    {
        
        _resourceManager._drillsOwned++;
        _resourceManager.PlaceDrill(IsDrilling);
        Debug.Log("PlacedDrill");
    }

}
