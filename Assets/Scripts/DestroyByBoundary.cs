using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByBoundary : MonoBehaviour
{
    //when the two objects are no longer touching...
    void OnTriggerExit(Collider other)
    {
        //destory the object that leaves the object this script is attached to
        if (other.tag != "Player")
        {
            Destroy(other.gameObject);
        }
        
    }

}
