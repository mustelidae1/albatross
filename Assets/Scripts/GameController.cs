using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//needed for Text
using UnityEngine.UI;
//needed for restarting the scene
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public GameObject hazard;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    //gives player a second to get feel for the ship controls
    public float startWait;
    public float waveWait;

    public Text restartText;
    public Text gameOverText;
    public Text scoreText;
    private int score;

    //vars to check for to restart and when game is over
    private bool gameOver;
    private bool restart;

    //starts this function on the first frame of the game
    void Start()
    {
        //flag boolean vars
        gameOver = false;
        restart = false;

        //labels will diplay nothing
        restartText.text = "";
        gameOverText.text = "";

        score = 0;
        UpdateScore();

        //SpawnWaves();  <---not co-routine
        StartCoroutine (SpawnWaves());
    }

    //void SpawnWaves()
    //for this to be a co-routine, replace void with IEnumerator
    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);

        //makes the for loop infinite
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                //random.range (min, max) values for asteroid spawn point on X axis
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                //Quaternion.identity cooresponds to no rotation at all
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);

                //this function needs to be a coroutine to work with this "waitForSeconds" thing
                //WaitForSeconds(spawnWait);   <----won't work
                yield return new WaitForSeconds(spawnWait);
            }

            waveWait -= 1;
            hazardCount += 3;

            yield return new WaitForSeconds(waveWait);

            if (gameOver)
            {
                restartText.text = "Press 'R' to Restart";
                restart = true;
                break;
            }
        }
    }

    private void Update()
    {
        //if restart equals true...
        if (restart)
        {
            //if R is pressed
            if (Input.GetKeyDown (KeyCode.R))
            {
                SceneManager.LoadScene("Main");
            }
        }
    }

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

    public void GameOver()
    {
        gameOverText.text = "Game Over!";
        gameOver = true;
    }

    void UpdateScore()
    {
        scoreText.text = "Score: " + score.ToString();
    }
}
