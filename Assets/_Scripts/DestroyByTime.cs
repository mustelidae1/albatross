using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Destroy game object after given lifetime.
/// </summary>

public class NewBehaviourScript : MonoBehaviour {

	//can edit the amount of time before destroyed
	public float lifetime;

	void Start ()
	{
		//specifying wait time before destroy takes effect
		Destroy(gameObject, lifetime);
	}
	
}
