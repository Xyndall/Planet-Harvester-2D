using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float _speed = 500;

    public Rigidbody2D _rb;

    public float _maxLifeTime = 2;
    


    public void Project(Vector2 direction)
    {
        _rb.AddForce(direction * _speed);

        Destroy(this.gameObject, _maxLifeTime);
    }

    

}
