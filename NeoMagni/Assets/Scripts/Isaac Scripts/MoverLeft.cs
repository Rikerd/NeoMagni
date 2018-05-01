using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverLeft : MonoBehaviour {

	private int direction;

	// Use this for initialization
	void Start () {
		direction = 1;
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.x > -0.65f) {
			direction = -1;
		}
		else if (transform.position.x < -4.8f) {
			direction = 1;
		}
	transform.Translate (0.025f * direction, 0, 0);
	}
}