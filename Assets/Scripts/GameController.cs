using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject hazard;
    public Vector2 spawnValues;
    public int numberOfHazards;
    public float spawnWaitTime;
    public float startWaitTime;
    public float waveWaitingTime;
    bool gameOver;
    bool restart;
    private PlayerHealth playerHealth;
    private GameObject player;
    private PlayerControl playerControl;

    public Text scoreText;
    public Text gameOverText;
    public Text restartText;
    private int score;


    void Start()
    {
        score = 0;
        gameOverText.text = "";
        restartText.text = "";
        StartCoroutine(SpawnWaves());
        gameOver = false;
        restart = false;

        //referance to player

        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        playerControl = player.GetComponent<PlayerControl>();


    }

    private void Update()
    {

        //check if player is dead
        if (playerHealth.currentHealth <= 0)
        {
            Dead();
            player.SetActive(false);
        }
        else if (score >= 10)
            Win();

        if(restart)
        {
            if(Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }



    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWaitTime);
        while (true)
        {
            for (int i=0; i < numberOfHazards; i++)
            {
                Vector2 spawnPosition = new Vector2(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
            }
            yield return new WaitForSeconds(waveWaitingTime);

            if(gameOver)
            {
                restartText.text = "PRESS 'R' TO RESTRAT";
                restart = true;
                break;
            }

                
        }
        
    }

    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }

    public void AddScore (int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

    public void Dead()
    {
        gameOverText.text = "You are dead!";
        gameOver = true;
    }

    public void Win()
    {
        gameOverText.text = "You Won!";
        gameOver = true;
        playerControl.enabled = false;
    }
}