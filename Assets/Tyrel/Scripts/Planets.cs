using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planets : MonoBehaviour
{

    public Drill PlayerOneDrill;
    public Drill PlayerTwoDrill;

    

     void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "PlayerOne")
        {
            
            PlayerOneDrill._overPlanet = true;


        }

        if(collision.gameObject.tag == "PlayerTwo")
        {
            PlayerTwoDrill._overPlanet = true;


        }

    }

     void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerOne")
        {
            
            PlayerOneDrill._overPlanet = false;
        }
        if (collision.gameObject.tag == "PlayerTwo")
        {
            PlayerOneDrill._overPlanet = false;
        }

    }

}
