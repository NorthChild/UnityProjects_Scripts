using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public static PlayerController playerController;

    public GameObject livesHolder;
    public GameObject scoreHolder;
    public GameObject gameOverHolder;

    int score = 0;
    public int lives = 3;

    public bool gameOver = false;

    public Text scoreText;
    public Text endGameScoreText;

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
        gameOverHolder.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncrementScore()
    {
        if (!gameOver)
        {
            score++;
            scoreText.text = score.ToString();
        }
    }

    public void DecreaseLives()
    {
        if (lives > 0)
        {
            lives--;
            livesHolder.transform.GetChild(lives).gameObject.SetActive(false);
        }
        
        if (lives <=0 )
        {
            GameOver();
        }

    }

    public void GameOver()
    {
        gameOver = true;
        livesHolder.gameObject.SetActive(false);
        scoreHolder.gameObject.SetActive(false);
        gameOverHolder.gameObject.SetActive(true);
        endGameScoreText.text = score.ToString();
        CandySpawner.instance.StopSpawingCandies();
    }
}
