using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float _speed = 500;

    Rigidbody2D _rb;

    public float _maxLifeTime = 10;
    
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();    
    }

    public void Project(Vector2 direction)
    {
        Debug.Log("Project");
        _rb.AddForce(direction * _speed);

        Destroy(this.gameObject, _maxLifeTime);
        Debug.Log("Destroyed Bullet");
    }



}
