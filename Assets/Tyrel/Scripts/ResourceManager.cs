using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ResourceManager : MonoBehaviour
{

    public int _resources;

    bool _drilling;
    public int _drillsOwned;

    void Start()
    {
        _resources = 0;
        _drillsOwned = 0;
    }


    private void FixedUpdate()
    {
        if (_drilling)
        {
            GainResource(_drillsOwned);
            Debug.Log("Resource Manager _drilling");
        }
    }

    void GainResource(int drillsOwned)
    {
        

        for(int i = 0; i < 100000; i++)
        {
            System.Threading.Thread.Sleep(1000);
            _resources += drillsOwned * 1;
        }

    }

    public void PlaceDrill(bool IsDrilling)
    {
        _drilling = IsDrilling;
        Debug.Log("IsDrilling");
    }


}
