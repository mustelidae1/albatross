using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlightController : MonoBehaviour {

    private Rigidbody rb; 

	// Use this for initialization
	void Start () {
        rb = this.GetComponent<Rigidbody>();
        Debug.Log(rb); 
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 force = new Vector3(0, 100, 0); 
        if (rb.velocity.y < 0) {
            force.x = -rb.velocity.y; 
        }
        if (Input.GetKey("space"))
        {
            Debug.Log("FORCE!");
            //Vector3 force = new Vector3(0, 10, 0); 
            rb.AddForce(new Vector3(0, 100, 0)); 
       //     rb.velocity = Vector3.Lerp(rb.velocity, transform.forward * rb.velocity.magnitude, Time.deltaTime / 1);
        }
	}
}
