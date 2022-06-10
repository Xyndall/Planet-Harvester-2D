using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{

    bool _isPaused;
    public GameObject _pauseScreen;

    // Start is called before the first frame update
    void Start()
    {
        _pauseScreen.SetActive(false);
        _isPaused = false;
    }

    // Update is called once per frame
    void Update()
    {

        

    }


    public void PauseGame()
    {
        Debug.Log("Paused");
        _isPaused = true;
        _pauseScreen.SetActive(true);
        Time.timeScale = 0;
    }
    public void ResumeGame()
    {
        _isPaused = false;
        _pauseScreen.SetActive(false);
        Time.timeScale = 1;
    }

}
