using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletOne : MonoBehaviour
{
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PlayerTwo")
        {
            
            PlayerTwo playerTwo = collision.gameObject.GetComponent<PlayerTwo>();
            
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up * 1000);

            playerTwo.FreezePlayer();
            

            Debug.Log("playerTwo Frozen");
            Destroy(gameObject);
        }
    }
}
