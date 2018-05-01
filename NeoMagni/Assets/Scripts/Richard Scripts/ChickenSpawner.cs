using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenSpawner : MonoBehaviour {

    public GameObject chicken;
    public float setSpawnTimer;

    public float spawnTimer;

	public GameObject basic;
	public GameObject moverL;
	public GameObject moverR;

	private float inner = 0.65f;
	private float middle = 2.5f;
	private float outer = 4.8f;

	private int spawns;

    // Use this for initialization
    void Start()
    {
        spawnTimer = setSpawnTimer;
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer -= Time.deltaTime;

        if (spawnTimer <= 0f)
        {
            Birth();
			// change later

			if (spawns > 45) {
				spawnTimer = 1.5f;
			} else if (spawns > 15) {
				spawnTimer = 1f;
			} else {
				spawnTimer = setSpawnTimer;
			}
			Debug.Log (spawns);
        }
    }


    // spits out the chickens at random positions
    void Birth()
    {
		spawns++;

		int x = 12;
		if (spawns > 30) {
			x = 7;
		}
		int position = Random.Range(1, x);

		switch (position)
		{
		case 1:
			Object.Instantiate(basic, new Vector3(-outer, -11f, -1f), Quaternion.identity);
			Object.Instantiate(basic, new Vector3(inner, -11f, -1f), Quaternion.identity);
			break;

		case 2:
			Object.Instantiate(basic, new Vector3(-inner, -11f, -1f), Quaternion.identity);
			Object.Instantiate(basic, new Vector3(outer, -11f, -1f), Quaternion.identity);
			break;
		case 3:
			Object.Instantiate(basic, new Vector3(-inner, -11f, -1f), Quaternion.identity);
			Object.Instantiate(basic, new Vector3(inner, -11f, -1f), Quaternion.identity);
			break;

		case 4:
			Object.Instantiate(basic, new Vector3(-outer, -11f, -1f), Quaternion.identity);
			Object.Instantiate(basic, new Vector3(outer, -11f, -1f), Quaternion.identity);
			break;
		case 5:
			Object.Instantiate(basic, new Vector3(-middle, -11f, -1f), Quaternion.identity);
			Object.Instantiate(basic, new Vector3(middle, -11f, -1f), Quaternion.identity);
			break;

		case 6:
			Object.Instantiate(basic, new Vector3(-outer, -11f, -1f), Quaternion.identity);
			Object.Instantiate(basic, new Vector3(middle, -11f, -1f), Quaternion.identity);
			break;
		case 7:
			Object.Instantiate(basic, new Vector3(-middle, -11f, -1f), Quaternion.identity);
			Object.Instantiate(basic, new Vector3(outer, -11f, -1f), Quaternion.identity);
			break;

		case 8:
			Object.Instantiate(moverL, new Vector3(-outer, -11f, -1f), Quaternion.identity);
			Object.Instantiate(basic, new Vector3(middle, -11f, -1f), Quaternion.identity);
			break;
		case 9:
			Object.Instantiate(moverR, new Vector3(outer, -11f, -1f), Quaternion.identity);
			Object.Instantiate(basic, new Vector3(-middle, -11f, -1f), Quaternion.identity);
			break;

		case 10:
			Object.Instantiate(moverL, new Vector3(-inner, -11f, -1f), Quaternion.identity);
			Object.Instantiate(moverR, new Vector3(inner, -11f, -1f), Quaternion.identity);
			break;

		case 11:
			Object.Instantiate(moverL, new Vector3(-outer, -11f, -1f), Quaternion.identity);
			Object.Instantiate(moverR, new Vector3(outer, -11f, -1f), Quaternion.identity);
			break;

		case 12:
			Object.Instantiate(moverL, new Vector3(-middle, -11f, -1f), Quaternion.identity);
			Object.Instantiate(moverR, new Vector3(middle, -11f, -1f), Quaternion.identity);
			break;
		}
	}
}
