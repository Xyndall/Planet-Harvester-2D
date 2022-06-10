using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameAnalyticsSDK;

public class InistializeAnalytics : MonoBehaviour
{
    void Start()
    {
        GameAnalytics.Initialize();
    }
}
