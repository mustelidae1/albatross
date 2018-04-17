using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Destroys child objects that are no longer colliding with the parent trigger object.
/// </summary>

public class DestroyByBoundary : MonoBehaviour
{
    //when the two objects are no longer touching...
    void OnTriggerExit(Collider other)
    {
        //destory the object that leaves the object this script is attached to
        Destroy(other.gameObject);
    }

}
