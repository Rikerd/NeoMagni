using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour {
    
    public Text timerText;

    private static float timer;

	// Use this for initialization
	void Start () {
        timer = 0f;
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;

        TimerStat.Minute = (int) (timer / 60);
        TimerStat.Second = (int) (timer % 60);

        timerText.text = string.Format("{0:00}:{1:00}", TimerStat.Minute, TimerStat.Second);
	}

    public static float Timer
    {
        get
        {
            return timer;
        }

        set
        {
            timer = value;
        }
    }
}
