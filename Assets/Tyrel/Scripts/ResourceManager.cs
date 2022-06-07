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
            StartCoroutine(GainResources(_drillsOwned));
            Debug.Log("Resource Manager _drilling");
        }
    }


    IEnumerator GainResources(int drillsOwned)
    {
        while (_resources < 100000000)
        {
            _resources += drillsOwned;
            yield return new WaitForSeconds(1);
            
        }
        
       
    }

    public void PlaceDrill(bool IsDrilling)
    {
        _drilling = IsDrilling;
        Debug.Log("IsDrilling");
    }


}
