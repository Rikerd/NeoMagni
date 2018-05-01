using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverRight : MonoBehaviour {

	public float movementSpeedY;
	public float movementSpeedX;
	private Rigidbody2D rb2d;
	public int direction;

	// Use this for initialization
	void Start () {
		direction = 1;
		rb2d = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update () {
		if (transform.position.x <= 0.65f) {
			direction = 1;
			transform.localScale = new Vector3 (0.6f, 0.6f, 0.6f);
		}
		else if (transform.position.x >= 4.8f) {
			direction = -1;
			transform.localScale = new Vector3 (-0.6f, 0.6f, 0.6f);
		}

		rb2d.MovePosition (transform.position + (transform.up * movementSpeedY)+ (transform.right * movementSpeedX * direction));
		//rb2d.MovePosition (transform.position + (transform.right * movementSpeedX * direction));
		//transform.Translate(movementSpeedX * direction, 0, 0);
	}

	void OnTriggerEnter2D(Collider2D hit)
	{
		if (hit.tag == "Player") {
			hit.gameObject.SetActive (false);
			GameManager.gameOver = true;
		} else if (hit.tag == "Hungry") {
			GameObject.Destroy (this.gameObject);
		}
	}

	private void OnBecameInvisible()
	{
		Destroy(gameObject);
	}
}
