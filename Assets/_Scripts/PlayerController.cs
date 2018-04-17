using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//separate class for defining boundaries
//this doesn't inherit from anything like PlayerController does
//Needs to be "Serializable" to be able to be seen in the Unity editor
[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;

}

public class PlayerController : MonoBehaviour
{
    //creating var for rigidbody
    private Rigidbody rb;
    //creating var for audioSource
    private AudioSource audioSource;
    private float nextFire;

    //making instance of Boundary
    //Boundary is type, boundary is reference
    public Boundary boundary;
    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;
    //public makes it editible in Unity
    public float speed;
    //declare var for tilt
    public float tilt;


    void Start ()
    {
        //assigning value for rb from the player's rigidbody
        rb = GetComponent<Rigidbody>();

        //assigning value for audioSource for the players AudioSource
        audioSource = GetComponent<AudioSource>();
    }

    //"update" executes all code in this function everyframe right before the frame
    void Update()
    {
        //Input.GetButton returns true when a buttun identified by buttonName is held down
        //nextFire starts at 0 so its true till the button is pressed
        if ((Input.GetButton("Fire1") || Input.GetButton("Jump")) && Time.time > nextFire)
        {
            //adds to the nextFire var when the button is pressed
            nextFire = Time.time + fireRate;

            //instantiate clones the objects original and returns the clone
            //need object, position, and rotation to set to
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);

            //play the current clip
            audioSource.Play();
        }
    }

    void FixedUpdate()
    {

        float moveHorizontal = Input.GetAxis ("Horizontal");
        float moveVertical = Input.GetAxis ("Vertical");

        //f means floating point number
        Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

        //speed effects movement
        rb.velocity = movement * speed;

        //limit the area the rigidbody can move within
        rb.position = new Vector3
            (
                //Mathf a collection of math functions
                //clamping the movement areas to the min and max variables for X
                Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax), 
                //no need to clamp area for Y
                0.0f,
                //clamping the movement areas to the min and max variables for Z
                Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)
            );

        //mulitply by negative tilt to twist in the right direction
        rb.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x * -tilt);
    }

    
}
