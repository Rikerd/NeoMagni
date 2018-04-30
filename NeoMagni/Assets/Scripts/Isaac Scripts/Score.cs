using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	public Text scoretxt;
	private int scorenum;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		scoretxt.text = "Score: " + (scorenum/2);
	}

	void OnTriggerEnter2D (Collider2D other) {
		scorenum++;
	}
}
