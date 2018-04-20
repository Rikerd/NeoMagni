using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(0, 0.05f, 0);
	}
	
	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.tag == "Player") {
            other.gameObject.SetActive(false);
		}
		
		if (other.gameObject.tag == "Hungry") {
			Destroy(this.gameObject);
		}
	}
}
