using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameAnalyticsSDK;

public class DestroyDuplicateGA : MonoBehaviour
{
    void Awake()
    {
        if (FindObjectsOfType<GameAnalytics>().Length > 1)
        {
            Destroy(gameObject);
        }

    }
}
