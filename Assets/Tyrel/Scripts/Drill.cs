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
    

    public DrillerScript _Drill;
    Vector2 _lastDrillPosition;
    public float _stealTime = 3;
    bool _canSteal;
    GameObject _drillLastTouched;

    public ProgressBar _progressBar;
    public GameObject _canvas;
    public Transform _SliderPosition;

    private void Start()
    {

        _isDrilling = false;
        _planetHasDrill = false;
        _hasDrill = false;
        _overPlanet = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && _overPlanet == true && _planetHasDrill == false && _playerNum == 1)
        {
            
            SpawnDrill();
        }

        if(Input.GetKeyDown(KeyCode.Comma) && _overPlanet == true && _planetHasDrill == false && _playerNum == 2)
        {

            SpawnDrill();
        }

        if(Input.GetKeyDown(KeyCode.Comma) && _canSteal && _playerNum == 2)
        {

            StartCoroutine(StealingDrillOne());
        }
        if(Input.GetKeyDown(KeyCode.F) && _canSteal && _playerNum == 1)
        {
            StartCoroutine(StealingDrillTwo());
        }


    }

    void SpawnDrill()
    {
        _isDrilling = true;
        _planets._hasDrill = true;
        _planetHasDrill = true;
        
        DrillerScript drill = Instantiate(_Drill, _lastDrillPosition, transform.rotation);
        drill.GetComponent<DrillerScript>()._resourceManager = this._resourceManager;
        drill.PlaceDrill(_isDrilling, _planets._planetSize);
    }


    IEnumerator StealingDrillOne()
    {
        _canSteal = false;
        PlayerTwo playerTwo = GetComponent<PlayerTwo>();
        playerTwo.GetComponent<PlayerTwo>()._playerisFrozen = true;
        ProgressBar progressBar = Instantiate(_progressBar, _SliderPosition.position, _SliderPosition.rotation);
        progressBar.transform.SetParent(_canvas.transform);
        yield return new WaitForSeconds(_stealTime);
        playerTwo.GetComponent<PlayerTwo>()._playerisFrozen = false;
        _drillLastTouched.GetComponent<DrillerScript>().DestroyDrill();
        Destroy(progressBar.gameObject);
        Destroy(_drillLastTouched);
        SpawnDrill();
    }

    IEnumerator StealingDrillTwo()
    {
        _canSteal = false;
        PlayerOne playerOne = GetComponent<PlayerOne>();
        playerOne.GetComponent<PlayerOne>()._playerisFrozen = true;
        ProgressBar progressBar = Instantiate(_progressBar, _SliderPosition.position, _SliderPosition.rotation);
        progressBar.transform.SetParent(_canvas.transform);
        yield return new WaitForSeconds(_stealTime);
        playerOne.GetComponent<PlayerOne>()._playerisFrozen = false;
        _drillLastTouched.GetComponent<DrillerScript>().DestroyDrill();
        Destroy(progressBar.gameObject);
        Destroy(_drillLastTouched);
        SpawnDrill();
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Planet" && _planetHasDrill == false)
        {
            _overPlanet = true;     
        }

        if (collision.gameObject.tag == "Drill1" && _playerNum != 1)
        {
            _canSteal = true;
            _drillLastTouched = collision.gameObject;
            
        }

        if (collision.gameObject.tag == "Drill2" && _playerNum != 2)
        {
            _canSteal = true;
            _drillLastTouched = collision.gameObject;
        }

        if (collision.gameObject.tag == "Planet")
        {
            _lastDrillPosition = collision.gameObject.transform.position;
            _planets = collision.gameObject.GetComponent<Planets>();
        }

    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Planet" 
            || collision.gameObject.tag == "Drill2" 
            || collision.gameObject.tag == "Drill1")
        {

            _overPlanet = false;
            _canSteal = false;
        }



    }


}
