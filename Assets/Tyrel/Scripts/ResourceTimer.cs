using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;

public class ResourceTimer : MonoBehaviour
{
    public static Stopwatch _resourceTimer;

    // Start is called before the first frame update
    void Awake()
    {
        _resourceTimer = new Stopwatch();
        _resourceTimer.Start();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
