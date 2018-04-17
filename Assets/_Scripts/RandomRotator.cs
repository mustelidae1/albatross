using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Randomly rotates GameObject by given value.
/// </summary>
/// 
public class RandomRotator : MonoBehaviour {

    public float tumble;

    private Rigidbody rb;

    private void Start()
    {
        //assigning value for rb from the player's rigidbody
        rb = GetComponent<Rigidbody>();

        //Random.insideUnitSphere returns a random point inside a sphere with radius 1
        rb.angularVelocity = Random.insideUnitSphere * tumble;
    }
}
