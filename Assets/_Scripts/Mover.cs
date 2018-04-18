using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Moves things... like rocks.
/// </summary>
public class Mover : MonoBehaviour {

    //creating var for rigidbody
    private Rigidbody rb;

    //declare speed variable
    public float speed;

    void Start()
    {
        //assigning value for rb from the player's rigidbody
        rb = GetComponent<Rigidbody>();

        //moves/tranforms the object forward according to speed var
        rb.velocity = transform.forward * speed;
    }
}
