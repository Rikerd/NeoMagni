﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetController : MonoBehaviour {

    public MagnetController player;

    public bool leftMagnet;

    public float movementDuration;

    public Transform modelTransform;

    private float inner = 0.65f;
    private float middle = 2.5f;
    private float outer = 4.8f;

    protected MagnetState currentState;
    private SpriteRenderer sprite;
    private bool moving;

    private Vector3 currentPosition;
    private float timePassed;
    
	private AudioSource src;

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

        //sprite = GetComponent<SpriteRenderer>();
        moving = false;
        timePassed = 0f;
        currentPosition = transform.position;

		src = GetComponent <AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (currentState == MagnetState.Neutral)
        {
            //transform.position = new Vector2(middle, transform.position.y);

            if (timePassed < movementDuration)
            {
                transform.position = Vector3.Lerp(currentPosition, new Vector3(middle, transform.position.y), timePassed / movementDuration);
                timePassed += Time.deltaTime;
            } else
            {
                moving = false;
            }
        } else if ((currentState == MagnetState.Red && player.currentState == MagnetState.Blue) || (currentState == MagnetState.Blue && player.currentState == MagnetState.Red))
        {
            //transform.position = new Vector2(inner, transform.position.y);

            if (timePassed < movementDuration)
            {
                transform.position = Vector3.Lerp(currentPosition, new Vector3(inner, transform.position.y), timePassed / movementDuration);
                timePassed += Time.deltaTime;
            }
            else
            {
                moving = false;
            }
        } else if ((currentState == MagnetState.Red && player.currentState == MagnetState.Red) || (currentState == MagnetState.Blue && player.currentState == MagnetState.Blue))
        {
            //transform.position = new Vector2(outer, transform.position.y);

            if (timePassed < movementDuration)
            {
                transform.position = Vector3.Lerp(currentPosition, new Vector3(outer, transform.position.y), timePassed / movementDuration);
                timePassed += Time.deltaTime;
            }
            else
            {
                moving = false;
            }
        } else
        {
            moving = false;
        }


        if (Input.GetKeyDown(KeyCode.A) && leftMagnet && !moving)
        {
            currentState = MagnetState.Red;
            Quaternion target = Quaternion.Euler(180, 0, -90);

            modelTransform.rotation = target;
            //sprite.color = Color.red;

            if ((currentState == MagnetState.Red && player.currentState == MagnetState.Red) || (currentState == MagnetState.Blue && player.currentState == MagnetState.Blue) ||
                ((currentState == MagnetState.Red && player.currentState == MagnetState.Blue) || (currentState == MagnetState.Blue && player.currentState == MagnetState.Red)))
            {
                setAnimationVariables();
                player.setAnimationVariables();
            }

			src.Play ();
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) && !leftMagnet && !moving)
        {
            currentState = MagnetState.Red;
            //sprite.color = Color.red;
            Quaternion target = Quaternion.Euler(180, 180, -90);

            modelTransform.rotation = target;

            if ((currentState == MagnetState.Red && player.currentState == MagnetState.Red) || (currentState == MagnetState.Blue && player.currentState == MagnetState.Blue) ||
                ((currentState == MagnetState.Red && player.currentState == MagnetState.Blue) || (currentState == MagnetState.Blue && player.currentState == MagnetState.Red)))
            {
                setAnimationVariables();
                player.setAnimationVariables();
            }

			src.Play ();
        }

        if (Input.GetKeyDown(KeyCode.D) && leftMagnet && !moving)
        {
            currentState = MagnetState.Blue;
            //sprite.color = Color.blue;
            Quaternion target = Quaternion.Euler(180, 180, 90);

            modelTransform.rotation = target;

            if ((currentState == MagnetState.Red && player.currentState == MagnetState.Red) || (currentState == MagnetState.Blue && player.currentState == MagnetState.Blue) ||
                ((currentState == MagnetState.Red && player.currentState == MagnetState.Blue) || (currentState == MagnetState.Blue && player.currentState == MagnetState.Red)))
            {
                setAnimationVariables();
                player.setAnimationVariables();
            }

			src.Play ();
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) && !leftMagnet && !moving)
        {
            currentState = MagnetState.Blue;
            //sprite.color = Color.blue;
            Quaternion target = Quaternion.Euler(180, 0, 90);

            modelTransform.rotation = target;

            if ((currentState == MagnetState.Red && player.currentState == MagnetState.Red) || (currentState == MagnetState.Blue && player.currentState == MagnetState.Blue) ||
                ((currentState == MagnetState.Red && player.currentState == MagnetState.Blue) || (currentState == MagnetState.Blue && player.currentState == MagnetState.Red)))
            {
                setAnimationVariables();
                player.setAnimationVariables();
            }

			src.Play ();
        }

        if (Input.GetKeyDown(KeyCode.S) && leftMagnet && !moving)
        {
            currentState = MagnetState.Neutral;
            //sprite.color = Color.white;
            Quaternion target = Quaternion.Euler(180, 0, 0);

            modelTransform.rotation = target;

            setAnimationVariables();

			src.Play ();
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) && !leftMagnet && !moving)
        {
            currentState = MagnetState.Neutral;
            //sprite.color = Color.white;
            Quaternion target = Quaternion.Euler(180, 180, 0);

            modelTransform.rotation = target;

            setAnimationVariables();

			src.Play ();
        }
    }

    void setAnimationVariables()
    {
        timePassed = 0f;
        moving = true;
        currentPosition = transform.position;
    }
}
