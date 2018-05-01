using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkedSpawner : NetworkBehaviour
{

    public GameObject chicken;
    public float setSpawnTimer;

    public float spawnTimer;

    [SyncVar]
    private int position;
    private GameObject[] players;

    // Use this for initialization
    void Start()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        spawnTimer = setSpawnTimer;
        position = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(players.Length < 2)
            players = GameObject.FindGameObjectsWithTag("Player");

        spawnTimer -= Time.deltaTime;

        if (spawnTimer <= 0f && CheckPlayers())
        {
            Birth();
            spawnTimer = setSpawnTimer;
        }
    }

    // checks if the players are still alive
    bool CheckPlayers()
    {
        if (players.Length == 2)
        {
            if (players[0] != null && players[1] != null && players[0].activeSelf && players[1].activeSelf)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        return false;
    }


    // spits out the chickens at random positions
    void Birth()
    {
        if (isServer)
            position = Random.Range(1, 6);

        switch (position)
        {
            case 1:
                Instantiate(chicken, new Vector3(-4.8f, transform.position.y, 0f), Quaternion.identity);
                break;
            case 2:
                Instantiate(chicken, new Vector3(-2.5f, transform.position.y, 0f), Quaternion.identity);
                break;
            case 3:
                Instantiate(chicken, new Vector3(-0.65f, transform.position.y, 0f), Quaternion.identity);
                break;
            case 4:
                Instantiate(chicken, new Vector3(0.65f, transform.position.y, 0f), Quaternion.identity);
                break;
            case 5:
                Instantiate(chicken, new Vector3(2.5f, transform.position.y, 0f), Quaternion.identity);
                break;
            case 6:
                Instantiate(chicken, new Vector3(4.8f, transform.position.y, 0f), Quaternion.identity);
                break;
        }
    }
}
