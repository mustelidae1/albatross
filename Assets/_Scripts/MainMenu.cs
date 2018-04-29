using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //Need this to switch between scenes

public class MainMenu : MonoBehaviour {

    public void PlayGame()
    {
        //load by scene number (find number in build settings) or load by "Scene Name"
        SceneManager.LoadScene(1);
        Time.timeScale = 1; 
    }

    public void QuitGame()
    {
        //quits the application in Mobile
        Debug.Log("QUIT!");
        Application.Quit();
    }
}
