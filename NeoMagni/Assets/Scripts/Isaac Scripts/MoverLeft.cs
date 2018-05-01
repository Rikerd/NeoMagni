using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverLeft : MonoBehaviour {

	public float movementSpeedY;
	public float movementSpeedX;
	private Rigidbody2D rb2d;
	private int direction;
	private AudioSource src;

	// Use this for initialization
	void Start () {
		direction = 1;
		rb2d = GetComponent<Rigidbody2D>();
		src = GetComponent<AudioSource> ();
	}

	// Update is called once per frame
	void Update()
	{
		if (transform.position.x > -0.65f) {
			direction = -1;
			transform.localScale = new Vector3 (-0.6f, 0.6f, 0.6f);
		} else if (transform.position.x < -4.8f) {
			direction = 1;
			transform.localScale = new Vector3 (0.6f, 0.6f, 0.6f);
		}
		
		rb2d.MovePosition (transform.position + (transform.up * movementSpeedY)+ (transform.right * movementSpeedX * direction));
	}

	void OnTriggerEnter2D(Collider2D hit)
	{
		if (hit.tag == "Player") {
			hit.gameObject.SetActive (false);
			GameManager.gameOver = true;
			src.Play ();
		} else if (hit.tag == "Hungry") {
			GameObject.Destroy (this.gameObject);
		}
	}

	private void OnBecameInvisible()
	{
		Destroy(gameObject);
	}
}