using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float moveSpeed;

    [SerializeField]
    float maxPos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.instance.gameOver)
        {
            Move();
        }
        else
        {

        }
    }

    private void Move()
    {
        float inputX = Input.GetAxis("Horizontal");
        float xPos = Mathf.Clamp(transform.position.x, -maxPos, maxPos);

        transform.position = new Vector3(xPos, transform.position.y, transform.position.z);
        transform.position += Vector3.right * inputX * moveSpeed * Time.deltaTime;
        
    }
}
