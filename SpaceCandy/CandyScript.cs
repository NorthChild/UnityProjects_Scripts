using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SocialPlatforms.Impl;

public class CandyScript : MonoBehaviour
{
    [SerializeField]
    float maxPosY;

    public static GameManager instance;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        DeleteCandiesOutsideBoundaries();
    }


    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            GameManager.instance.IncrementScore();
            Destroy(gameObject);
        }
    }

    void DeleteCandiesOutsideBoundaries()
    {
        if (transform.position.y < maxPosY)
        {
            GameManager.instance.DecreaseLives();
            Destroy(gameObject);
        }
    }
}
