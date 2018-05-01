using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameState : NetworkBehaviour
{

    public GameObject player1;
    public GameObject player2;

    public GameObject GameOverScreen;
    public Text gameOverText;

    [SyncVar]
    public bool gameOver;

    public string status; //"repel" or "attract" or "neither"
    private GameManager gameManager;
    private static GameState playerInstance;
    private int sceneID;


    // Use this for initialization
    void Start () {
        DontDestroyOnLoad(gameObject);
        if (playerInstance == null)
        {
            playerInstance = this;
        }
        else
        {
            DestroyObject(gameObject);
        }
        status = "neither";
        gameOver = false;
        GameOverScreen.SetActive(false);

        sceneID = SceneManager.GetActiveScene().buildIndex;
        //gameManager = GetComponent<GameManager>();
    }
	
	// Update is called once per frame
	void Update () {
        if (player1 != null && player2 != null)
        {
            updatePlayers();
            if (!player1.activeSelf || !player2.activeSelf)
            {
                gameOver = true;
                GameObject timeManager = GameObject.Find("Timer Manager");
                timeManager.GetComponent<NetworkedTimerManager>().stopped = true;
                gameOverText.text = "Survived for " + string.Format("{0:00}:{1:00}", TimerStat.Minute, TimerStat.Second);
            }
        }
        GameOverScreen.SetActive(gameOver);

        sceneID = SceneManager.GetActiveScene().buildIndex;
        if (sceneID != 4)
        {
            gameOver = false;
            GameOverScreen.SetActive(false);
            if (GetComponent<NetworkedTimerManager>() != null)
                GetComponent<NetworkedTimerManager>().stopped = true;
        }
    }

    public void setPlayer(GameObject player)
    {
        if (player1 == null)
        {
            player1 = player;
            player.GetComponent<PlayerController>().setPlayerNum(1);
        }
        else
        {
            player2 = player;
            player.GetComponent<PlayerController>().setPlayerNum(2);
        }
    }

    private void updatePlayers()
    {
        changePlayerLooks(player1);
        changePlayerLooks(player2);

        changePlayerLocations();
    }

    private void changePlayerLocations()
    {
        PlayerController player1Controller = player1.GetComponent<PlayerController>();
        PlayerController player2Controller = player2.GetComponent<PlayerController>();

        checkRepelAttract(player1Controller, player2Controller);

        if (status == "neither")
        {
            if (player1Controller.state == 0)
                player1Controller.movePlayer("middle");
            if (player2Controller.state == 0)
                player2Controller.movePlayer("middle");
        }
        else if (status == "repel")
        {
            player1Controller.movePlayer("outer");
            player2Controller.movePlayer("outer");
        }
        else if (status == "attract")
        {
            player1Controller.movePlayer("inner");
            player2Controller.movePlayer("inner");
        }

    }

    private void checkRepelAttract(PlayerController controller1, PlayerController controller2)
    {
        if (controller1.state == 0 || controller2.state == 0) {
            status = "neither";
            return; }
        if ((controller1.state == 1 && controller2.state == 1) ||
            (controller1.state == 2 && controller2.state == 2))
        {
            status = "repel";
            return;
        }
        if ((controller1.state == 1 && controller2.state == 2) ||
            (controller1.state == 2 && controller2.state == 1))
        {
            status = "attract";
            return;
        }
    }

    private void changePlayerLooks(GameObject player)
    {
        Transform modelTransform = player.GetComponent<Transform>();
        if (player.GetComponent<PlayerController>().state == 0)
        {
            //player.GetComponent<SpriteRenderer>().color = Color.white;
            if (player == player1) //left magnet
            {
                modelTransform.rotation = Quaternion.Euler(180, 0, 0);
            }
            if (player == player2) //right magnet
            {
                modelTransform.rotation = Quaternion.Euler(180, 180, 0);
            }
        }
        if (player.GetComponent<PlayerController>().state == 1)
        {
            //player.GetComponent<SpriteRenderer>().color = Color.red;
            if (player == player1) //left magnet
            {
                modelTransform.rotation = Quaternion.Euler(180, 0, -90);
            }
            if (player == player2) //right magnet
            {
                modelTransform.rotation = Quaternion.Euler(180, 180, -90);
            }
        }
        if (player.GetComponent<PlayerController>().state == 2)
        {
            //player.GetComponent<SpriteRenderer>().color = Color.blue;
            if (player == player1) //left magnet
            {
                modelTransform.rotation = Quaternion.Euler(180, 180, 90);
            }
            if (player == player2) //right magnet
            {
                modelTransform.rotation = Quaternion.Euler(180, 0, 90);
            }
        }
    }
}
