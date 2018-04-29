using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class Mover : MonoBehaviour {

    //pulling in the timer class to get timeElapsed as a float
    private GameObject timer;
    private GameObject rocks;
    public float timeElasped;
    private float rockNumber;
    
    //creating var for rigidbody
    private Rigidbody rb;

    //declare speed variable
    public int speed = 5;
    //public float speedMod = 1;


    void Start()
    {
        //assigning value for rb from the player's rigidbody
        rb = GetComponent<Rigidbody>();

        //find the "TimeElapsed" game object and assign it to the timer var
        timer = GameObject.Find("TimeElasped");
        //get the timer script from the timer var game object and get it's timeElapsed variable and then assign it to timeElapsed
        timeElasped = timer.GetComponent<Timer>().timeElasped;

        //assign the game object "Boundary" to the rocks variable
        rocks = GameObject.Find("Boundary");

        //use the rocks variable to get the DestroyByBoundary script and divided the rocksDestroyed variable within by 10
        //assign that value to the var rockNumber
        rockNumber = rocks.GetComponent<DestroyByBoundary>().rocksDestroyed / 10;

        //We can't let the rock speed get toooooo fast can we??
        if(rockNumber >= 9)
        {
            rockNumber = 9;
        }

        //show the current rock value in the console
        Debug.Log("rockNumber = " + rockNumber);

        //moves/tranforms the object forward according to speed var
        rb.velocity = transform.forward * speed * (rockNumber + 1);
    }

}
