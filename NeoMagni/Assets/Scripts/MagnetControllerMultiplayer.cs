using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class MagnetControllerMultiplayer : NetworkBehaviour
{

    public MagnetControllerMultiplayer player;

    public bool leftMagnet;

    public float movementDuration;

    private float inner = 0.65f;
    private float middle = 1.4f;
    private float outer = 2.3f;

    protected MagnetState currentState;
    private SpriteRenderer sprite;
    private bool moving;

    private Vector3 currentPosition;
    private float timePassed;


    public enum MagnetState
    {
        Red,
        Blue,
        Neutral
    }

    // Use this for initialization
    void Start()
    {
        currentState = MagnetState.Neutral;

        if (leftMagnet)
        {
            inner = -inner;
            middle = -middle;
            outer = -outer;
        }

        sprite = GetComponent<SpriteRenderer>();
        moving = false;
        timePassed = 0f;
        currentPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        ////////////MOVEMENT BASED ON STATES////////////////
        if (currentState == MagnetState.Neutral)
        {
            if (timePassed < movementDuration)
            {
                transform.position = Vector3.Lerp(currentPosition, new Vector3(middle, transform.position.y), timePassed / movementDuration);
                timePassed += Time.deltaTime;
            }
            else
            {
                moving = false;
            }
        }
        else if ((currentState == MagnetState.Red && player.currentState == MagnetState.Blue) || (currentState == MagnetState.Blue && player.currentState == MagnetState.Red))
        {
            if (timePassed < movementDuration)
            {
                transform.position = Vector3.Lerp(currentPosition, new Vector3(inner, transform.position.y), timePassed / movementDuration);
                timePassed += Time.deltaTime;
            }
            else
            {
                moving = false;
            }
        }
        else if ((currentState == MagnetState.Red && player.currentState == MagnetState.Red) || (currentState == MagnetState.Blue && player.currentState == MagnetState.Blue))
        { 
            if (timePassed < movementDuration)
            {
                transform.position = Vector3.Lerp(currentPosition, new Vector3(outer, transform.position.y), timePassed / movementDuration);
                timePassed += Time.deltaTime;
            }
            else
            {
                moving = false;
            }
        }
        else
        {
            moving = false;
        }

        ////////////////////////INPUT////////////////////////////
        if (Input.GetKeyDown(KeyCode.A) && leftMagnet && !moving)
        {
            currentState = MagnetState.Red;
            sprite.color = Color.red;

            if ((currentState == MagnetState.Red && player.currentState == MagnetState.Red) || (currentState == MagnetState.Blue && player.currentState == MagnetState.Blue) ||
                ((currentState == MagnetState.Red && player.currentState == MagnetState.Blue) || (currentState == MagnetState.Blue && player.currentState == MagnetState.Red)))
            {
                setAnimationVariables();
                player.setAnimationVariables();
            }
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) && !leftMagnet && !moving)
        {
            currentState = MagnetState.Red;
            sprite.color = Color.red;

            if ((currentState == MagnetState.Red && player.currentState == MagnetState.Red) || (currentState == MagnetState.Blue && player.currentState == MagnetState.Blue) ||
                ((currentState == MagnetState.Red && player.currentState == MagnetState.Blue) || (currentState == MagnetState.Blue && player.currentState == MagnetState.Red)))
            {
                setAnimationVariables();
                player.setAnimationVariables();
            }
        }

        if (Input.GetKeyDown(KeyCode.D) && leftMagnet && !moving)
        {
            currentState = MagnetState.Blue;
            sprite.color = Color.blue;

            if ((currentState == MagnetState.Red && player.currentState == MagnetState.Red) || (currentState == MagnetState.Blue && player.currentState == MagnetState.Blue) ||
                ((currentState == MagnetState.Red && player.currentState == MagnetState.Blue) || (currentState == MagnetState.Blue && player.currentState == MagnetState.Red)))
            {
                setAnimationVariables();
                player.setAnimationVariables();
            }
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) && !leftMagnet && !moving)
        {
            currentState = MagnetState.Blue;
            sprite.color = Color.blue;

            if ((currentState == MagnetState.Red && player.currentState == MagnetState.Red) || (currentState == MagnetState.Blue && player.currentState == MagnetState.Blue) ||
                ((currentState == MagnetState.Red && player.currentState == MagnetState.Blue) || (currentState == MagnetState.Blue && player.currentState == MagnetState.Red)))
            {
                setAnimationVariables();
                player.setAnimationVariables();
            }
        }

        if (Input.GetKeyDown(KeyCode.S) && leftMagnet && !moving)
        {
            currentState = MagnetState.Neutral;
            sprite.color = Color.white;

            setAnimationVariables();
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) && !leftMagnet && !moving)
        {
            currentState = MagnetState.Neutral;
            sprite.color = Color.white;

            setAnimationVariables();
        }
    }

    void setAnimationVariables()
    {
        timePassed = 0f;
        moving = true;
        currentPosition = transform.position;
    }
}
