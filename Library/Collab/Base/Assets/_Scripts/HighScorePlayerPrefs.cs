using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScorePlayerPrefs : MonoBehaviour
{
    static public HighScorePlayerPrefs S; // singleton

    static public int score = 0;
    public Text displayScores;
    public Text nameText;
    public Text scoreText; 

    private void Awake()
    {
        S = this; 
        // Player prefs values will last even after you close the game
        // and across different builds on the same computer. 
        if (PlayerPrefs.HasKey("HighScore"))
        {
            score = PlayerPrefs.GetInt("HighScore");
        }

        // This will create the key if it does not already exist 
        PlayerPrefs.SetInt("HighScore", score);
        if (PlayerPrefs.GetString("Name") == null)
            PlayerPrefs.SetString("Name", "no name");
        
        
    }

    public void AddScore()
    {
        int.TryParse(scoreText.GetComponent<Text>().text.ToString(), out score); 
        //score = scoreText.text; 
        print("Checking score: " + score); 
        
        if (score > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", score);
            print("Adding score " + score + " to HighScore playerPref"); 
        }
        PlayerPrefs.SetString("Name", nameText.text);

        displayScore(); 
    }

    public bool isScore(int newScore)
    {
        score = newScore;
        bool isHighScore = false;
        if (newScore > PlayerPrefs.GetInt("HighScore"))
        {
            isHighScore = true;
        }
        return isHighScore;
    }

    public void displayScore()
    {
        //Debug.Log("Current high score " + PlayerPrefs.GetInt("HighScore")); 
        displayScores.text = PlayerPrefs.GetString("Name") + " : " + PlayerPrefs.GetInt("HighScore").ToString(); 
    }
}
