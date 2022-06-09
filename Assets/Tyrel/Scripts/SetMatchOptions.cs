using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class SetMatchOptions : MonoBehaviour
{

    public Slider _planetSlider;
    public Slider _TimeSlider;

    public TextMeshProUGUI _planets;
    public TextMeshProUGUI _timer;

    void Start()
    {
        _planetSlider.GetComponent<Slider>();
        _TimeSlider.GetComponent<Slider>();
        _planets.GetComponent<TextMeshProUGUI>();
        _timer.GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        _timer.text = "" + _TimeSlider.value;
        _planets.text = "" + _planetSlider.value;
    }

    public void SetMatchTime()
    {
        LevelTimer._timer = _TimeSlider.value * 100;
    }

    public void NumberOfPlanets()
    {
        RandomlySpawnPlanets._planetsSpawned = (int)_planetSlider.value;
    }


}
