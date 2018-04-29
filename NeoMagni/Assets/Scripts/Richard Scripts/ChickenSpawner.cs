using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenSpawner : MonoBehaviour {

    public GameObject chicken;
    public float setSpawnTimer;

    public float spawnTimer;

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
            spawnTimer = setSpawnTimer;
        }
    }


    // spits out the chickens at random positions
    void Birth()
    {
        int position = Random.Range(1, 6);

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
