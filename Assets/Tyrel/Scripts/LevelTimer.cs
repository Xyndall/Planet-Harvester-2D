using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Diagnostics;

public class LevelTimer : MonoBehaviour
{
    public static float _timer = 300;
    public bool _timerRunning;
    TextMeshProUGUI text;


    public GameObject _winScreen;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        _winScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(_timer > 0)
        {
            _timer -= Time.deltaTime;
            DisplayTime(_timer);
            _timerRunning = true;
        }
        else
        {
            _winScreen.SetActive(true);
            Time.timeScale = 0;
            _timerRunning = false;
        }

        

        
    }

    void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        text.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }
}
