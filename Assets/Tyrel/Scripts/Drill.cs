using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drill : MonoBehaviour
{

    public ResourceManager _resourceManager;
    Planets _planets;

    public bool _isDrilling;

    public bool _overPlanet;

    public int _playerNum;

    public bool _hasDrill;

    public bool _planetHasDrill;


    private void Start()
    {

        _isDrilling = false;
        _planetHasDrill = false;
        _hasDrill = false;
        _overPlanet = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && _overPlanet == true && _planetHasDrill == false 
            || Input.GetKeyDown(KeyCode.Comma) && _overPlanet == true && _planetHasDrill == false)
        {
            _isDrilling = true;
            _planets._hasDrill = true;
            _planets._playerDrillNum = _playerNum;
            _planetHasDrill = true;
            PlaceDrill(_isDrilling);
            Debug.Log("Drilling " + _planets._hasDrill + _planets._playerDrillNum);
        }

        
    }


    public void PlaceDrill(bool IsDrilling)
    {
        
        _resourceManager._drillsOwned++;
        _resourceManager.PlaceDrill(IsDrilling);
        Debug.Log("PlacedDrill");
    }



    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Planet" && _planetHasDrill == false)
        {

            _overPlanet = true;
            _planets = collision.gameObject.GetComponent<Planets>();
            
        }




    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Planet")
        {

            _overPlanet = false;
        }


    }


}
