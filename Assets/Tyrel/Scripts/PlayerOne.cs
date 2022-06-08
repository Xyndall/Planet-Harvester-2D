using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOne : MonoBehaviour
{
    public Bullet _bulletPrefab;


    public float _thrustSpeed = 5;
    public float _turnSpeed = 1;
    public float _reverseSpeed = -2;

    private bool _thrusting;
    private bool _reverse;
    private float _turnDir;

    Rigidbody2D _rb;

    public bool _playerisFrozen;

    private float _fireRatetimer = 0;
    public float _TimeToFire = 2;

    public ProgressBar _progressBar;
    public GameObject _canvas;
    public Transform _SliderPosition;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        _thrusting = Input.GetKey(KeyCode.W);
        _reverse = Input.GetKey(KeyCode.S);

        if (Input.GetKey(KeyCode.A) && _playerisFrozen == false)
        {
            _turnDir = 1.0f;
        }
        else if (Input.GetKey(KeyCode.D) && _playerisFrozen == false)
        {
            _turnDir = -1f;
        }
        else
        {
            _turnDir = 0.0f;
        }



        _fireRatetimer += Time.deltaTime;


        if (Input.GetKeyDown(KeyCode.G) && _playerisFrozen == false && _fireRatetimer >= _TimeToFire)
        {
            Shoot();
            _fireRatetimer = 0.0f;
        }


    }

    void FixedUpdate()
    {
        
        if( _thrusting && _playerisFrozen == false)
        {
            _rb.AddForce(transform.up * _thrustSpeed);
        }

        if (_reverse && _playerisFrozen == false)
        {
            _rb.AddForce(transform.up * _reverseSpeed);
        }

        if(_turnDir != 0 && _playerisFrozen == false)
        {
            _rb.AddTorque(_turnDir * _turnSpeed);
        }

    }

    void Shoot()
    {
        Bullet bullet = Instantiate(_bulletPrefab, transform.position, transform.rotation);
        bullet.Project(transform.up);
        Debug.Log("Shoot");
    }



    public void FreezePlayer()
    {
        _playerisFrozen = true;
        StartCoroutine(PlayerFrozen());
    }

    IEnumerator PlayerFrozen()
    {
        ProgressBar progressBar = Instantiate(_progressBar, _SliderPosition.position, _SliderPosition.rotation);
        progressBar.transform.SetParent(_canvas.transform);
        yield return new WaitForSeconds(3);
        Destroy(progressBar.gameObject);
        Debug.Log("PlayerOne Unfroze");
        _playerisFrozen = false;

    }

}
