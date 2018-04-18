using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlightController : MonoBehaviour {

    private Rigidbody rb;

    [Header("Set in inspector")]
    public float speedy = 30;
    public float speedz = 50; 
    //public float rollMult = -45;
    public float pitchMult = 30;
    public float gravity = -1f; 

    // Use this for initialization
    void Start () {
        rb = this.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 pos = transform.position;

        float yAxis = Input.GetAxis("Vertical");
        
        if (yAxis == 0)
        {
            yAxis = gravity; 
        }
       
        pos.y += yAxis * speedy * Time.deltaTime;
        pos.z += yAxis * speedz * Time.deltaTime;
       

        transform.position = pos;

        // Rotate the albatross 
        transform.rotation = Quaternion.Euler(yAxis * pitchMult, 0, 0);
        
	}
}
