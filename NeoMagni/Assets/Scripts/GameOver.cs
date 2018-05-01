using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {

    public Text text;

    private float timer;

	// Use this for initialization
	void Start ()
    {

        text.text = "Survived for " + string.Format("{0:00}:{1:00}", TimerStat.Minute, TimerStat.Second);
    }
}
