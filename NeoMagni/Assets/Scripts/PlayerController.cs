using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour
{

    public GameObject gameState;
    public int playerNum;

    public float movementDuration;

    private float inner = 0.65f;
    private float middle = 2.5f;
    private float outer = 4.8f;

    [SyncVar]
    public int state; //0 = neutral, 1 = red, 2=blue
    public MagnetState currentState;
    private SpriteRenderer sprite;

    private bool moving;
    public Vector3 currentPosition;
    private float timePassed;

    public enum MagnetState
    {
        Neutral,
        Red,
        Blue
    }

    // Use this for initialization
    void Start()
    {
        setGameState();

        if (playerNum == 1) //leftMagnet
        {
            inner = -inner;
            middle = -middle;
            outer = -outer;
        }

        currentState = MagnetState.Neutral;
        state = 0;

      //sprite = GetComponent<SpriteRenderer>();
        moving = false;
        timePassed = 0f;
        currentPosition = new Vector3(middle, 7, 0);
  
        transform.position = currentPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (isLocalPlayer)
            handleInput();
        //print(playerNum + " player currentPosition: " + currentPosition);
        //print(transform.position);
    }

    public MagnetState getMagnetState()
    {
        return currentState;
    }

    public void movePlayer(string position)
    {
        float lane = middle;

        switch (position)
        {
            case "middle":
                lane = middle;
                break;
            case "inner":
                lane = inner;
                break;
            case "outer":
                lane = outer;
                break;
            default:
                lane = middle;
                break;
        }

        if (timePassed < movementDuration)
        {
            transform.position = Vector3.Lerp(currentPosition, new Vector3(lane, 7, 0), timePassed / movementDuration);
            timePassed += Time.deltaTime;
        }
        else
        {
            moving = false;
            setAnimationVariables();
        }
    }

    public void setPlayerNum(int num)
    {
        playerNum = num;
    }

    private void setGameState()
    {
        if (gameState == null)
        {
            gameState = GameObject.FindGameObjectWithTag("GameController");
            print(gameState);
        }
        gameState.GetComponent<GameState>().setPlayer(gameObject);
    }

    private void handleInput()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            currentState = MagnetState.Neutral;
            //sprite.color = Color.white;
            CmdSetState(0);
        }
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            currentState = MagnetState.Neutral;
            //sprite.color = Color.white;
            CmdSetState(0);
        }
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            currentState = MagnetState.Red;
            //sprite.color = Color.red;
            CmdSetState(1);
        }
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            currentState = MagnetState.Blue;
            //sprite.color = Color.blue;
            CmdSetState(2);
        }
    }

    void setAnimationVariables()
    {
        timePassed = 0f;
        moving = true;
        currentPosition = transform.position;
    }

    [Command]
    private void CmdSetState(int playerColor)
    {
        state = playerColor;
    }
}
