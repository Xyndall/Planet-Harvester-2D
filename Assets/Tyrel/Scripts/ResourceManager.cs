using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ResourceManager : MonoBehaviour
{

    public int _resources;

    bool _drilling;
    public int _drillsOwned;

    public float timerLimit = 1.0f;
    private float timer = 0.0f;

    public int _upgraded;


    void Start()
    {
        _upgraded = 1;
        _resources = 0;
        _drillsOwned = 0;
    }



    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 1.0f && _drilling)
        {

            GainResource(_drillsOwned);
            timer = 0.0f;
        }


        
    }



    void GainResource(int drillsOwned)
    {
        _resources += drillsOwned * _upgraded;
    }



    public void PlaceDrill(bool IsDrilling)
    {
        _drilling = IsDrilling;

    }


}
