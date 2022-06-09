using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SetMatchOptions : MonoBehaviour
{

    public Slider _planetSlider;
    public Slider _TimeSlider;

    void Start()
    {
        _planetSlider = GetComponent<Slider>();
        _TimeSlider = GetComponent<Slider>();
    }

    public void SetMatchTime()
    {
        LevelTimer._timer = _TimeSlider.value;
    }

    public void NumberOfPlanets()
    {
        RandomlySpawnPlanets._planetsSpawned = (int)_planetSlider.value;
    }


}
