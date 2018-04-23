using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mother : MonoBehaviour {


    public GameObject progenitor;

    private int timer;
    private GameObject[] players;

	// Use this for initialization
	void Start () {
        players = GameObject.FindGameObjectsWithTag("Player");
    }
	
	// Update is called once per frame
	void Update () {
        if (players.Length < 2)
            players = GameObject.FindGameObjectsWithTag("Player");
        timer++;
        if (timer > 60 && CheckPlayers())
        {
            Birth();
            timer = 0;
        }

        // finish this later
	}


    // checks if the players are still alive
    bool CheckPlayers ()
    {
        if (players.Length == 2)
        {
            if (players[0].activeSelf && players[1].activeSelf)
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
    void Birth ()
    {
        int position = Random.Range(1, 6);

        switch (position)
        {
            case 1:
                Object.Instantiate(progenitor, new Vector3(-2.5f, -4.5f, 0f), Quaternion.identity);
                break;

            case 2:
                Object.Instantiate(progenitor, new Vector3(-1.5f, -4.5f, 0f), Quaternion.identity);
                break;
            case 3:
                Object.Instantiate(progenitor, new Vector3(-0.5f, -4.5f, 0f), Quaternion.identity);
                break;

            case 4:
                Object.Instantiate(progenitor, new Vector3(0.5f, -4.5f, 0f), Quaternion.identity);
                break;
            case 5:
                Object.Instantiate(progenitor, new Vector3(1.5f, -4.5f, 0f), Quaternion.identity);
                break;

            case 6:
                Object.Instantiate(progenitor, new Vector3(2.5f, -4.5f, 0f), Quaternion.identity);
                break;
        }
    }
}
