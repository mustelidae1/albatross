using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//needed for Text
using UnityEngine.UI;
//needed for restarting the scene
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public GameObject hazard1;
    public GameObject hazard2;
    public GameObject hazard3;

    private GameObject rocks;
    private float rockNumber;

    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;

    //vars to check for to restart and when game is over
    private bool gameOver;
    private bool restart;

    //starts this function on the first frame of the game
    void Start()
    {
        //flag boolean vars
        gameOver = false;
        restart = false;

        rocks = GameObject.Find("Boundary");

        //SpawnWaves();  <---not co-routine
        StartCoroutine (SpawnWaves());
    }

    //for this to be a co-routine, replace void with IEnumerator
    IEnumerator SpawnWaves()
    {

        //makes the for loop infinite
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                //random.range (min, max) values for asteroid spawn point on X axis
                Vector3 spawnPosition1 = new Vector3(spawnValues.x, Random.Range(spawnValues.y-4, spawnValues.y+3), spawnValues.z);
                Vector3 spawnPosition2 = new Vector3(spawnValues.x + 35, Random.Range(spawnValues.y - 10, spawnValues.y), spawnValues.z-15);
                Vector3 spawnPosition3 = new Vector3(spawnValues.x + 20, Random.Range(spawnValues.y - 10, spawnValues.y), spawnValues.z - 30);
                //Quaternion.identity cooresponds to no rotation at all
                Quaternion spawnRotation = Quaternion.Euler(0,90,Random.Range(0, 90));

                Instantiate(hazard1, spawnPosition1, spawnRotation);
                Instantiate(hazard2, spawnPosition2, spawnRotation);
                Instantiate(hazard3, spawnPosition3, spawnRotation);

                yield return new WaitForSeconds(spawnWait);
            }

            //don't let the spawn time get faster than one second
            if(spawnWait <= 1)
            {
                spawnWait = 1;
            }
            else
            {
                //decreases the spawnWait over time
                spawnWait -= spawnWait * .075f;
                Debug.Log("spawnWait = " + spawnWait);
            }

        }
    }

}
