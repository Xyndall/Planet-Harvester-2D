using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class WinScreen : MonoBehaviour
{

    public ResourceManager _PlayerOneResources;
    public ResourceManager _PlayerTwoResources;

    public LevelTimer _timeFinished;

    public TextMeshProUGUI _winnerText;

    // Start is called before the first frame update
    void Start()
    {
        _PlayerOneResources.GetComponent<ResourceManager>();
        _PlayerTwoResources.GetComponent<ResourceManager>();
        _timeFinished.GetComponent<LevelTimer>();
        _winnerText.GetComponent<TextMeshProUGUI>();

    }

    // Update is called once per frame
    void Update()
    {
        
        if(_timeFinished._timerRunning == false)
        {
            _PlayerOneResources._maxResourcesGained = _PlayerOneResources._resources;
            _PlayerTwoResources._maxResourcesGained = _PlayerTwoResources._resources;

            if(_PlayerOneResources._maxResourcesGained > _PlayerTwoResources._maxResourcesGained)
            {
                _winnerText.text = "Player One Wins";
            }
            else
            {
                _winnerText.text = "Player Two Wins";
            }

        }

    }
}
