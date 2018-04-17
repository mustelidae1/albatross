using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

/// <summary>
/// Must be attached to text a text object.
/// 
/// This class creates a timer that keeps track of total time elasped 
/// over the course of the session.
/// </summary>
public class Timer : MonoBehaviour {
    private float timeElasped = 0; 
    private Text timeElaspedText; // Text object which we will be accessing.

    private void Start()
    {
        timeElaspedText = this.GetComponent<Text>();  // Getting text component of object.
    }

    void Update () {
        
        if (timeElaspedText != null) // Make sure not null.
        {
            timeElaspedText.text = timeElasped.ToString(); // Set the text equal to time elasped
        }
        timeElasped += Time.deltaTime; // Adding each time interval between frames to timeElasped.
        
	}
}
