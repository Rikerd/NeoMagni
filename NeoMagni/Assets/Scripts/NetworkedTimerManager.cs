using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class NetworkedTimerManager : NetworkBehaviour
{
    public Text timerText;
    public bool stopped;

    [SyncVar]
    private float timer;

    // Use this for initialization
    void Start()
    {
        timer = 0f;
        stopped = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (stopped)
            return;

        if (isServer)
            timer += Time.deltaTime;

        TimerStat.Minute = (int)(timer / 60);
        TimerStat.Second = (int)(timer % 60);

        timerText.text = string.Format("{0:00}:{1:00}", TimerStat.Minute, TimerStat.Second);
    }
}
