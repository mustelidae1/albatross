using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {

	public GameObject explosion;
	public GameObject playerExplosion;

	public int scoreValue;
	//needed to designate the instance for the variable
	private GameController gameController;

	void Start()
	{
		//need to find gameobject that holds gameController script
		//this will find the first object that we put in the scene with the game controller Tag
		GameObject gameControllerObject = GameObject.FindWithTag("GameController");
		//if we find the game controller object...
		if(gameControllerObject != null)
		{
			//set the game controller ref to the game controller component on the GC object
			gameController = gameControllerObject.GetComponent<GameController>();
		}

		//if it fails, then we will see debug
		if(gameController == null)
		{
			Debug.Log("Cannot find 'GameController' script");
		}
	}

	void OnTriggerEnter(Collider other)
	{
		
		//if other is Boundary tagged, ignore it (end this function)
		if(other.tag == "Boundary" || other.tag == "Asteroid")
		{
			return;
		}

		//instatiates the asteroid explosion during the collision of the bolt
		Instantiate(explosion, transform.position, transform.rotation);

		if(other.tag == "Player")
		{
			//instantiates the player explosion during the collision of the player
			Instantiate(playerExplosion, other.transform.position, other.transform.rotation);

			//when player is destroyed the gameController is told the game is over
			gameController.GameOver ();
		}
		

		//figuring out why asteroid is destroyed, use debug.log to find the culprit
		//Debug.Log(other.name);

		//marks objects to be destroyed at the end of the frame
		Destroy(other.gameObject);
		Destroy(gameObject);

		//the variable already references the right instance of GameController
		gameController.AddScore(scoreValue);
	}
}
