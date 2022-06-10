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

    public bool _playerisFrozen;

    private float _fireRatetimer = 0;
    public float _TimeToFire = 2;

    public GameObject _upgradeUI;
    bool _isOpened;

    public ProgressBar _progressBar;
    public GameObject _canvas;
    public Transform _SliderPosition;

    public AudioSource _audioSource;
    public AudioSource _Thrusters;
    public AudioClip[] _audioClip;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _playerisFrozen = false;
        _isOpened = false;
        _thrustSpeed = 5;
        _turnSpeed = 1;
        _reverseSpeed = -2;
    }

    void Update()
    {
        _thrusting = Input.GetKey(KeyCode.UpArrow);
        _reverse = Input.GetKey(KeyCode.DownArrow);

        if (Input.GetKey(KeyCode.LeftArrow) && _playerisFrozen == false)
        {
            _turnDir = 1.0f;
        }
        else if (Input.GetKey(KeyCode.RightArrow) && _playerisFrozen == false)
        {
            _turnDir = -1f;
        }
        else
        {
            _turnDir = 0.0f;
        }


        _fireRatetimer += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Period) && _playerisFrozen == false && _fireRatetimer >= _TimeToFire)
        {
            Shoot();
            _fireRatetimer = 0.0f; 
        }

        if (Input.GetKeyDown(KeyCode.Slash))
        {
            _isOpened = !_isOpened;
        }
        

        if (_isOpened)
        {
            _upgradeUI.SetActive(true);
        }
        else
        {
            _upgradeUI.SetActive(false);
        }

    }

    void PlayThrusters()
    {
        _Thrusters.PlayOneShot(_audioClip[1]);
    }

    void FixedUpdate()
    {

        if (_thrusting && _playerisFrozen == false)
        {
            _rb.AddForce(transform.up * _thrustSpeed);
            
        }

        if (_reverse && _playerisFrozen == false)
        {
            _rb.AddForce(transform.up * _reverseSpeed);
        }

        if (_turnDir != 0 && _playerisFrozen == false)
        {
            _rb.AddTorque(_turnDir * _turnSpeed);
        }

    }

    void Shoot()
    {
        Bullet bullet = Instantiate(_bulletPrefab, transform.position, transform.rotation);
        bullet.Project(transform.up);
        PlayAudio(0);
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
        Debug.Log("PlayerTwo Unfroze");
         _playerisFrozen = false;

    }

    void PlayAudio(int aClip)
    {
        _audioSource.PlayOneShot(_audioClip[aClip]);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            PlayAudio(2);
            
        }
    }
}
