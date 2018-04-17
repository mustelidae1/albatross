using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Acts like a vertical boost for when player hits the parent object.
/// </summary>

public class Wind : MonoBehaviour
{
    public float windSpeed; // Amount of vertical boost
    private void OnTriggerEnter(Collider coll)
    {
        print("Enter OnTriggerEnter");
        // Just a shortcut for collided GameObject.
        GameObject collidedWith = coll.gameObject;
        // If the colliding body has "Player" tag.
        if (collidedWith.tag == "Player") 
        {
            // Add up force to parent rigid body of 
            collidedWith.GetComponent<Rigidbody>().AddForce(Vector3.up * windSpeed);
        }
    }
}
