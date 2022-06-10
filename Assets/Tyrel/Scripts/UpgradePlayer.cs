using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpgradePlayer : MonoBehaviour
{
    public ResourceManager _resourceManager;
    public Drill _drill;
    public PlayerTwo _playerTwo;

    public int _resourceUpgradeCost = 200;
    public int _boostupgradeCost = 100;
    public int _fireRateUpgradeCost = 100;
    public int _drillStealCost = 300;

    public TextMeshProUGUI __resourceText;
    public TextMeshProUGUI _boostText;
    public TextMeshProUGUI _fireRateText;
    public TextMeshProUGUI _drillStealText;

    void Start()
    {
        _resourceManager.GetComponent<ResourceManager>();
        _drill.GetComponent<Drill>();
        _playerTwo.GetComponent<PlayerTwo>();

        _resourceUpgradeCost = 200;
        _boostupgradeCost = 100;
        _fireRateUpgradeCost = 100;
        _drillStealCost = 300;
    }

    private void Update()
    {
        __resourceText.text = "" + _resourceUpgradeCost;
        _boostText.text = "" + _boostupgradeCost;
        _drillStealText.text = "" + _drillStealCost;
        _fireRateText.text = "" + _fireRateUpgradeCost;
    }

    public void UpgradeResources()
    {
        if(_resourceManager._resources >= _resourceUpgradeCost)
        {
            
            _resourceManager._upgraded++;
            _resourceManager._resources -= _resourceUpgradeCost;
            _resourceUpgradeCost += 120;
            Debug.Log("Upgraded Resources" + _resourceManager._upgraded);
        }
    }

    public void UpgradeBoost()
    {
        if (_resourceManager._resources >= _boostupgradeCost)
        {
            Debug.Log("Upgraded Boost");
            _playerTwo._thrustSpeed = _playerTwo._thrustSpeed  * 2;
            _playerTwo._reverseSpeed = _playerTwo._reverseSpeed * 2;
            _playerTwo._turnSpeed = _playerTwo._turnSpeed * 2;
            _resourceManager._resources -= _boostupgradeCost;
            _boostupgradeCost += 1000;

        }
    }

    public void UpgradeFireRate()
    {
        if (_resourceManager._resources >= _fireRateUpgradeCost)
        {
            
            _playerTwo._TimeToFire = _playerTwo._TimeToFire / 2;
            _resourceManager._resources -= _fireRateUpgradeCost;
            _fireRateUpgradeCost += 500;
            Debug.Log("Upgraded fireRate" + _playerTwo._TimeToFire);
        }
    }

    public void UpgradeDrillSteal()
    {
        if (_resourceManager._resources >= _drillStealCost)
        {
            
            _drill._stealTime = _drill._stealTime / 2;
            _resourceManager._resources -= _drillStealCost;
            _drillStealCost += 2000;
            Debug.Log("Upgraded DrillStealSpeed" + _drill._stealTime);
        }
    }

}
