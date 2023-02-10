using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed = 20f;
    private float leftBound = -20f;
    private PlayerController playerControllerScript;

    public bool sprinting;

    private int totalScore;





    // Start is called before the first frame update
    void Start()
    {
        totalScore = 0;
        playerControllerScript = GameObject.Find("RunnerChar").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
         if (playerControllerScript.gameOver == false)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        
        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            totalScore++;
            Debug.Log("Survived " + (totalScore - 1) + " obstacles! keep it up!!");
            Destroy(gameObject);            
        }

        DoubleSpeed();
    }


    public void DoubleSpeed()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && !playerControllerScript.gameOver && !sprinting && playerControllerScript.isOnGround)
        {
            speed = 35f;
            sprinting = true;

        }
        else if (Input.GetKeyUp(KeyCode.LeftShift) && !playerControllerScript.gameOver && sprinting)
        {
            speed = 20f;
            sprinting = false;

        }
    }
}
