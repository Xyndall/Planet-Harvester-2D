using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTwo : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PlayerOne")
        {
            PlayerOne playerOne = collision.gameObject.GetComponent<PlayerOne>();
            

            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up * 1000);

            
            playerOne.FreezePlayer();

            Debug.Log("playerOne Frozen");
            Destroy(gameObject);
        }
    }
}
