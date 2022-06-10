using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using GameAnalyticsSDK;

public class WinScreen : MonoBehaviour
{

    public ResourceManager _PlayerOneResources;
    public ResourceManager _PlayerTwoResources;

    public LevelTimer _timeFinished;

    public TextMeshProUGUI _winnerText;

    public TextMeshProUGUI _playerOneText;
    public TextMeshProUGUI _playerTwoText;

    int _MaxPlayerOneResources;
    int _MaxPlayerTwoResources;

    int PlayerWhoWon;

    // Start is called before the first frame update
    void Start()
    {
        _PlayerOneResources.GetComponent<ResourceManager>();
        _PlayerTwoResources.GetComponent<ResourceManager>();
        _timeFinished.GetComponent<LevelTimer>();
        _winnerText.GetComponent<TextMeshProUGUI>();
        _playerOneText.GetComponent<TextMeshProUGUI>();
        _playerTwoText.GetComponent<TextMeshProUGUI>();

        
    }

    void SendAnalytics()
    {
        
        GameAnalytics.NewDesignEvent("Player Who one", PlayerWhoWon);
        GameAnalytics.NewDesignEvent("Player One Resources", _MaxPlayerOneResources);
        GameAnalytics.NewDesignEvent("Player Two Resources", _MaxPlayerTwoResources);

    }


    // Update is called once per frame
    void Update()
    {
        
        if(_timeFinished._timerRunning == false)
        {
            _PlayerOneResources._maxResourcesGained = _PlayerOneResources._resources;
            _PlayerTwoResources._maxResourcesGained = _PlayerTwoResources._resources;

            _MaxPlayerOneResources = _PlayerOneResources._maxResourcesGained;
            _MaxPlayerTwoResources = _PlayerTwoResources._maxResourcesGained;

            if(_MaxPlayerOneResources > _MaxPlayerTwoResources)
            {
                _winnerText.text = "Player One Wins";
                _playerOneText.text = "" + _MaxPlayerOneResources;
                _playerTwoText.text = "" + _MaxPlayerTwoResources;
                PlayerWhoWon = 1;
                SendAnalytics();
            }
            else if (_MaxPlayerTwoResources > _MaxPlayerOneResources)
            {
                _winnerText.text = "Player Two Wins";
                _playerOneText.text = "" + _MaxPlayerOneResources;
                _playerTwoText.text = "" + _MaxPlayerTwoResources;
                PlayerWhoWon = 2;
                SendAnalytics();
            }
            else
            {
                _winnerText.text = "Tie";
                _playerOneText.text = "" + _MaxPlayerOneResources;
                _playerTwoText.text = "" + _MaxPlayerTwoResources;
                PlayerWhoWon = 0;
                SendAnalytics();
            }

        }

        

    }

}
