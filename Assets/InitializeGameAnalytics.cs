using System.Collections;
using System.Collections.Generic;
using GameAnalyticsSDK;
using UnityEngine;

public class InitializeGameAnalytics : MonoBehaviour
{
    void Start()
    {
        GameAnalytics.Initialize();
    }
}
