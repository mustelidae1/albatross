using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Main : MonoBehaviour {
    private float timeElasped = 0;
    private Text timeElaspedText;

    private void Start()
    {
        timeElaspedText = this.GetComponent<Text>();
    }

    void Update () {
        
        if (timeElaspedText != null)
        {
            timeElaspedText.text = timeElasped.ToString();
        }
        timeElasped += Time.deltaTime;
        
	}
}
