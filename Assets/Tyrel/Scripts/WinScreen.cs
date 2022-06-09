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

    public TextMeshProUGUI _playerOneText;
    public TextMeshProUGUI _playerTwoText;

    int _MaxPlayerOneResources;
    int _MaxPlayerTwoResources;


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
            }
            else if (_MaxPlayerTwoResources > _MaxPlayerOneResources)
            {
                _winnerText.text = "Player Two Wins";
                _playerOneText.text = "" + _MaxPlayerOneResources;
                _playerTwoText.text = "" + _MaxPlayerTwoResources;
            }
            else
            {
                _winnerText.text = "Tie";
                _playerOneText.text = "" + _MaxPlayerOneResources;
                _playerTwoText.text = "" + _MaxPlayerTwoResources;
            }

        }

        

    }
}
