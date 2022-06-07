using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planets : MonoBehaviour
{

    public bool _hasDrill;
    public int _playerDrillNum;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "PlayerOne" || collision.gameObject.tag == "PlayerTwo")
        {
            Drill drill = collision.gameObject.GetComponent<Drill>();
            drill._planetHasDrill = _hasDrill;
        }

        
    }

}
