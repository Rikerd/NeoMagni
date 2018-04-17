using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetController : MonoBehaviour {

    public MagnetController player;

    public bool leftMagnet;

    private float inner = 0.65f;
    private float middle = 1.4f;
    private float outer = 2.3f;

    private MagnetState currentState;

    public enum MagnetState
    {
        Red,
        Blue,
        Neutral
    }

	// Use this for initialization
	void Start () {
        currentState = MagnetState.Neutral;

        if (leftMagnet)
        {
            inner = -inner;
            middle = -middle;
            outer = -outer;
        }
	}
	
	// Update is called once per frame
	void Update () {
		if (currentState == MagnetState.Neutral)
        {
            transform.position = new Vector2(inner, transform.position.y);
        }
	}
}
