using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTwo : MonoBehaviour
{
    public Bullet _bulletPrefab;


    public float _thrustSpeed;
    public float _turnSpeed;
    public float _reverseSpeed;

    private bool _thrusting;
    private bool _reverse;
    private float _turnDir;

    Rigidbody2D _rb;

    public bool _PlayerisFrozen;

    private float _fireRatetimer = 0;
    public float _TimeToFire = 2;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _PlayerisFrozen = false;
    }

    void Update()
    {
        _thrusting = Input.GetKey(KeyCode.UpArrow);
        _reverse = Input.GetKey(KeyCode.DownArrow);

        if (Input.GetKey(KeyCode.LeftArrow) && _PlayerisFrozen == false)
        {
            _turnDir = 1.0f;
        }
        else if (Input.GetKey(KeyCode.RightArrow) && _PlayerisFrozen == false)
        {
            _turnDir = -1f;
        }
        else
        {
            _turnDir = 0.0f;
        }


        _fireRatetimer += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Period) && _PlayerisFrozen == false && _fireRatetimer >= _TimeToFire)
        {
            Shoot();
            _fireRatetimer = 0.0f; 
        }


    }

    void FixedUpdate()
    {

        if (_thrusting && _PlayerisFrozen == false)
        {
            _rb.AddForce(transform.up * _thrustSpeed);
        }

        if (_reverse && _PlayerisFrozen == false)
        {
            _rb.AddForce(transform.up * _reverseSpeed);
        }

        if (_turnDir != 0 && _PlayerisFrozen == false)
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
        _PlayerisFrozen = true;
        StartCoroutine(PlayerFrozen());
    }

    IEnumerator PlayerFrozen()
    {
        yield return new WaitForSeconds(3);
        Debug.Log("PlayerTwo Unfroze");
         _PlayerisFrozen = false;

    }


}