using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{


    public GameObject _pauseScreen;

    // Start is called before the first frame update
    void Start()
    {
        _pauseScreen.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();

        }

    }


    public void PauseGame()
    {
        Debug.Log("Paused");

        _pauseScreen.SetActive(true);
        Time.timeScale = 0;
    }
    public void ResumeGame()
    {

        _pauseScreen.SetActive(false);
        Time.timeScale = 1;
    }

}
