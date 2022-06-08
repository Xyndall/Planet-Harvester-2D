using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPositionOfAudioListener : MonoBehaviour
{
    public Transform camera1;
    public Transform camera2;
 
    void Update()
    {
        transform.position = new Vector2(camera1.position.x /2, camera1.position.y /2) + new Vector2(camera2.position.x /2, camera2.position.y /2);
    }
}
