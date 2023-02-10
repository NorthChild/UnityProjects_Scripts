using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandySpawner : MonoBehaviour
{
    [SerializeField]
    float maxPosY;
    float maxPosX = 6.5f;

    [SerializeField]
    float spawnInterval;

    public GameObject[] candyGroup;

    public static CandySpawner instance;
    public static GameManager inst;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        StartSpawingCandies();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnCandy()
    {
        int candyIndex = Random.Range(0, candyGroup.Length);
        float randomMaxPosX = Random.Range(-maxPosX, maxPosX);

        Vector3 randomPosX = new Vector3(randomMaxPosX, transform.position.y, transform.position.z);

        Instantiate(candyGroup[candyIndex], randomPosX, transform.rotation);
    }

    IEnumerator SpawnCandies()
    {
        yield return new WaitForSeconds(1f);
        while (!GameManager.instance.gameOver)
        {
            SpawnCandy();
            yield return new WaitForSeconds(spawnInterval);
        } 
    }

    public void StartSpawingCandies()
    {
        StartCoroutine("SpawnCandies");
    }

    public void StopSpawingCandies()
    {
        StopCoroutine("SpawnCandies");
        Debug.Log("stop candies");
    }
}

