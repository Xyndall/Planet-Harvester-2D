using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOne : MonoBehaviour
{
    public Bullet _bulletPrefab;


    public float _thrustSpeed;
    public float _turnSpeed;
    public float _reverseSpeed;

    private bool _thrusting;
    private bool _reverse;
    private float _turnDir;

    Rigidbody2D _rb;

    public bool _playerisFrozen;

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

        if (Input.GetKeyDown(KeyCode.G) && _playerisFrozen == false)
        {
            Shoot();
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
        yield return new WaitForSeconds(3);
        Debug.Log("PlayerOne Unfroze");
        _playerisFrozen = false;

    }

}
