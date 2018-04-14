using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour
{
    public float windSpeed;
    private void OnTriggerEnter(Collider coll)
    {
        print("Enter OnTriggerEnter");
        GameObject collidedWith = coll.gameObject;
        if (collidedWith.tag == "Player")
        {
            collidedWith.GetComponent<Rigidbody>().AddForce(Vector3.up * windSpeed);
        }
    }
}
