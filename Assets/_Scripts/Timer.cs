using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Timer : MonoBehaviour {

    public float timeElasped = 0;
    private Text timeElaspedText;

    private void Start()
    {
        timeElaspedText = this.GetComponent<Text>();
    }

    void Update () {
        
        if (timeElaspedText != null && HighScorePlayerPrefs.S.gameOver == false)
        {
            timeElaspedText.text = timeElasped.ToString();

            string[] strArr = null;
            strArr = timeElaspedText.text.Split('.');
            timeElaspedText.text = strArr[0]; 
        }

        timeElasped += Time.deltaTime;
	}
}
