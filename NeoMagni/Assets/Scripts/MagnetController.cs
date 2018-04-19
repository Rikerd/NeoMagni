using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetController : MonoBehaviour {

    public MagnetController player;

    public bool leftMagnet;

    private float inner = 0.65f;
    private float middle = 1.4f;
    private float outer = 2.3f;

    protected MagnetState currentState;
    private SpriteRenderer sprite;

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

        sprite = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		if (currentState == MagnetState.Neutral)
        {
            transform.position = new Vector2(middle, transform.position.y);
        }

        if ((currentState == MagnetState.Red && player.currentState == MagnetState.Blue) || (currentState == MagnetState.Blue && player.currentState == MagnetState.Red))
        {
            transform.position = new Vector2(inner, transform.position.y);
        }

        if ((currentState == MagnetState.Red && player.currentState == MagnetState.Red) || (currentState == MagnetState.Blue && player.currentState == MagnetState.Blue))
        {
            transform.position = new Vector2(outer, transform.position.y);
        }


        if (Input.GetKeyDown(KeyCode.A) && leftMagnet)
        {
            currentState = MagnetState.Red;
            sprite.color = Color.red;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) && !leftMagnet)
        {
            currentState = MagnetState.Red;
            sprite.color = Color.red;
        }

        if (Input.GetKeyDown(KeyCode.D) && leftMagnet)
        {
            currentState = MagnetState.Blue;
            sprite.color = Color.blue;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) && !leftMagnet)
        {
            currentState = MagnetState.Blue;
            sprite.color = Color.blue;
        }

        if (Input.GetKeyDown(KeyCode.S) && leftMagnet)
        {
            currentState = MagnetState.Neutral;
            sprite.color = Color.white;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) && !leftMagnet)
        {
            currentState = MagnetState.Neutral;
            sprite.color = Color.white;
        }
    }
}
