using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstaclePrefab;

    //public GameObject backgroundObject;
    private Vector3 spawnPosition = new Vector3(25, 1, 0);

    private PlayerController playerControllerScript;

    public float startDelay = 2;
    public float repeatRate = 2;

    

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("RunnerChar").GetComponent<PlayerController>();
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObstacle()
    {
        if (playerControllerScript.gameOver == false)
        {
            int obstacle = Random.Range(0, obstaclePrefab.Length);
            Instantiate(obstaclePrefab[obstacle], spawnPosition, Quaternion.identity);            
        }
    }

}

