using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ProgressBar : MonoBehaviour
{
	public Slider slider;

    public float _fillSpeed = 1f;
    float targetProcess = 0;

    private void Start()
    {
        UpdateSlider(3);
    }

    private void Update()
    {
        if (slider.value < targetProcess)
            slider.value += _fillSpeed * Time.deltaTime;
    }

    void UpdateSlider(float value)
	{
		targetProcess = slider.value + value;
	}
}
