using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chicken : MonoBehaviour {

    public float movementSpeed;

    private Rigidbody2D rb2d;
	private AudioSource src;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
		src = GetComponent<AudioSource> ();
    }

    // Update is called once per frame
    void Update()
    {
        rb2d.MovePosition(transform.position + (transform.up * movementSpeed));
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
