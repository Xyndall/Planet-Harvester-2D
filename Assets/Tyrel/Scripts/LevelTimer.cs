using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Diagnostics;

public class LevelTimer : MonoBehaviour
{
    public static Stopwatch _timer;
    TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        _timer = new Stopwatch();
        _timer.Start();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = _timer.Elapsed.ToString(@"mm\:ss\.ff");
    }
}
