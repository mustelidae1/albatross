using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Allows player to control flight of albatross.
/// </summary>

public class FlightController : MonoBehaviour {

    private Rigidbody rb;
    public int verticalForce; // Up force of albatross.

	void Start () {
        rb = this.GetComponent<Rigidbody>(); // Getting rigid body of parent object.
        print(rb); 
	}
	
	void Update () {
        Vector3 force = new Vector3(0, verticalForce, 0); 
        if (Input.GetKey("space")) // When player hits space bar...
        {
            Debug.Log("FORCE!"); 
            rb.AddForce(force); // Add a vertical force of 100.
        }
	}
}
