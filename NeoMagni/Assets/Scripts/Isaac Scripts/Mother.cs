using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mother : MonoBehaviour {


    public GameObject basic;
	public GameObject moverL;
	public GameObject moverR;

    private int timer;
	private int gametime;
    private GameObject[] players;

	private float inner = 0.65f;
	private float middle = 2.5f;
	private float outer = 4.8f;

	// Use this for initialization
	void Start () {
        players = GameObject.FindGameObjectsWithTag("Player");
    }
	
	// Update is called once per frame
	void Update () {
		int spawnrate = 120;

        if (players.Length < 2)
            players = GameObject.FindGameObjectsWithTag("Player");
        timer++;

		if (gametime > 1800) {
			spawnrate = 90;
		}
		if (gametime > 3600) {
			spawnrate = 60;
		}

        if (timer > spawnrate && CheckPlayers())
        {
            Birth();
            timer = 0;
        }

		gametime++;
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
		int x = 7;
		if (gametime > 2700) {
			x = 10;
		}
        int position = Random.Range(1, x);

        switch (position)
        {
            case 1:
                Object.Instantiate(basic, new Vector3(-outer, -4.5f, 0f), Quaternion.identity);
				Object.Instantiate(basic, new Vector3(inner, -4.5f, 0f), Quaternion.identity);
				break;

            case 2:
				Object.Instantiate(basic, new Vector3(-inner, -4.5f, 0f), Quaternion.identity);
				Object.Instantiate(basic, new Vector3(outer, -4.5f, 0f), Quaternion.identity);
				break;
            case 3:
				Object.Instantiate(basic, new Vector3(-inner, -4.5f, 0f), Quaternion.identity);
				Object.Instantiate(basic, new Vector3(inner, -4.5f, 0f), Quaternion.identity);
				break;

            case 4:
				Object.Instantiate(basic, new Vector3(-outer, -4.5f, 0f), Quaternion.identity);
				Object.Instantiate(basic, new Vector3(outer, -4.5f, 0f), Quaternion.identity);
				break;
            case 5:
				Object.Instantiate(basic, new Vector3(-middle, -4.5f, 0f), Quaternion.identity);
				Object.Instantiate(basic, new Vector3(middle, -4.5f, 0f), Quaternion.identity);
				break;

            case 6:
				Object.Instantiate(basic, new Vector3(-outer, -4.5f, 0f), Quaternion.identity);
				Object.Instantiate(basic, new Vector3(middle, -4.5f, 0f), Quaternion.identity);
				break;
			case 7:
				Object.Instantiate(basic, new Vector3(-middle, -4.5f, 0f), Quaternion.identity);
				Object.Instantiate(basic, new Vector3(outer, -4.5f, 0f), Quaternion.identity);
				break;

			case 8:
				Object.Instantiate(moverL, new Vector3(-outer, -4.5f, 0f), Quaternion.identity);
				Object.Instantiate(basic, new Vector3(middle, -4.5f, 0f), Quaternion.identity);
				break;
			case 9:
				Object.Instantiate(moverR, new Vector3(outer, -4.5f, 0f), Quaternion.identity);
				Object.Instantiate(basic, new Vector3(-middle, -4.5f, 0f), Quaternion.identity);
				break;

			case 10:
				Object.Instantiate(moverL, new Vector3(-inner, -4.5f, 0f), Quaternion.identity);
				Object.Instantiate(moverR, new Vector3(inner, -4.5f, 0f), Quaternion.identity);
				break;
        }
    }
}
