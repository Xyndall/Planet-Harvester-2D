using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrillerScript : MonoBehaviour
{
    public ResourceManager _resourceManager;

    public void PlaceDrill(bool IsDrilling)
    {

        _resourceManager._drillsOwned++;
        _resourceManager.PlaceDrill(IsDrilling);
        Debug.Log("PlacedDrill");
    }

    public void DestroyDrill()
    {
        _resourceManager._drillsOwned--;
    }
}
