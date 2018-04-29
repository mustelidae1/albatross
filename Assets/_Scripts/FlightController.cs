using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//separate class for defining boundaries
//this doesn't inherit from anything like FlightController does
//Needs to be "Serializable" to be able to be seen in the Unity editor
[System.Serializable]
public class Boundary
{
    [Header("Set in Inspector")]
    public float xMin = -20f;
    public float xMax = 25f;
    public float yMin = -5.75f;
    public float yMax = 10f;
    public float zMin = 50f;
    public float zMax = 100f;
}

/// <summary>
/// Controls albatross flight 
/// </summary>
public class FlightController : MonoBehaviour {


    private Rigidbody rb;
    private Quaternion calibrationQuaternion;

    //making instance of Boundary
    //Boundary is type, boundary is reference
    public Boundary boundary;

    [Header("Public Movement Parameters")]
    public float speedy = 30;
    public float speedz = 50;
    public float speedx = 50;
    public float pitchMult = 30;
    public float gravity = -1f;

    private Animator A;

    void Start () {

        A = DestroyByContact.anim;

        // Get rigidbody from current object 
        rb = this.GetComponent<Rigidbody>();
        CalibrateAccelerometer();

        // Lock device orientation and prevent it from going into sleep
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }

    // Used to calibrate the Input.acceleration - from https://forum.unity.com/threads/input-acceleration-calibration.317121/
    void CalibrateAccelerometer()
    {
        Vector3 accelerationSnapshot = Input.acceleration;

        Quaternion rotateQuaternion = Quaternion.FromToRotation(
            new Vector3(0.0f, 0.0f, -1.0f), accelerationSnapshot);

        calibrationQuaternion = Quaternion.Inverse(rotateQuaternion);
    }

    void FixedUpdate() {
        if (HighScorePlayerPrefs.S.gameOver == false)
        {
            // Get position of albatross 
            Vector3 pos = transform.position;

            // Get vertical input from Input Manager - will be a value between 1 and -1 - this is for keyboard movement 
            // float yAxis = Input.GetAxis("Vertical");


            // Ger input from device accelerometer 
            Vector3 input = Vector3.zero;

            input = calibrationQuaternion * Input.acceleration;

            if (input.sqrMagnitude > 1)
            {
                input.Normalize();
            }

            // Get individual components of input 
            float yAxis = input.y;
            float xAxis = input.x;

            /* if (yAxis == 0)  // No y input detected 
            {
                yAxis = gravity;
            } */

            // Adjust y (vertical) and z (horizontal) movement according to vertical input 
            pos.y += yAxis * speedy * Time.deltaTime;
            pos.z += yAxis * speedz * Time.deltaTime;
            pos.x += xAxis * speedx * Time.deltaTime;

            // Apply values to the albatross's position 
            transform.position = pos;

            // Rotate the albatross based on movement
            transform.rotation = Quaternion.Euler(yAxis * pitchMult, 0, 0);

            //limit the area the rigidbody can move within
            rb.position = new Vector3(
                                         //Mathf a collection of math functions
                                         //clamping the movement areas to the min and max variables for X
                                         Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),

                                         //clamping the movement areas to the min and max variables for X
                                         Mathf.Clamp(rb.position.y, boundary.yMin, boundary.yMax),

                                         //clamping the movement areas to the min and max variables for Z
                                         Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)
                                        );
            //if (GetComponent<DestroyByContact>().isHit == true)
            //{
            //    pos = this.GetComponentInParent<Transform>().position;
            //}
            //////////////////////////////////////////////////////////
            //USE CODE BELOW THIS LINE FOR TESTING GAME ON DESKTOP (COMMENT OUT UPDATE CODE ABOVE)
            //////////////////////////////////////////////////////////
            //Vector3 pos = transform.position;

            //float yAxis = Input.GetAxis("Vertical");
            //float xAxis = Input.GetAxis("Horizontal");

            //if (yAxis == 0)
            //{
            //    yAxis = gravity;
            //}

            //pos.x += xAxis * speedx * Time.deltaTime;
            //pos.y += yAxis * speedy * Time.deltaTime;
            //pos.z += yAxis * speedz * Time.deltaTime;

            //transform.position = pos;

            //// Rotate the albatross 
            //transform.rotation = Quaternion.Euler(yAxis * pitchMult, 0, 0);

            ////limit the area the rigidbody can move within
            //rb.position = new Vector3(
            //                             //Mathf a collection of math functions
            //                             //clamping the movement areas to the min and max variables for X
            //                             Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),


            //                             //clamping the movement areas to the min and max variables for Y
            //                             Mathf.Clamp(rb.position.y, boundary.yMin, boundary.yMax),

            //                             //clamping the movement areas to the min and max variables for Z
            //                             Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)
            //                            );
            //////////////////////////////////////////////////////////
        }
    }
    
}
