using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; 


public class DestroyByContact : MonoBehaviour
{

    private GameObject lastTriggeredGo;

    public GameObject failTextGO;
    private TextMeshProUGUI failText; 
    public Text scoreText;
    public InputField nameField;
    public Button submitButton; 
    public Text nameText; 

    public Canvas gameOverCanvas;

    public static Animator anim; 


    void Start()
    {
        failText = failTextGO.GetComponent<TextMeshProUGUI>(); 
        //make sure the Fail Menu is not enabled
        gameOverCanvas.gameObject.SetActive(false);

        anim = GetComponent<Animator>(); 
    }

    void OnTriggerEnter(Collider other)
    {


        //instead of hitting wing or cockpit, you hit the parent game object
        //assign the transform of other.gameobject's parent to the var rootT
        Transform rootT = other.gameObject.transform.root; 

        //assign the rooT transform t the var go (of GameObject type)
        GameObject go = rootT.gameObject;

        //make sure its not he last triggering game object as last time
        if (go == lastTriggeredGo)
        {
            //if it is the same game object, ignore it as a duplicate
            return;
        }

        lastTriggeredGo = go;


        if (go.tag == "Asteroid") //if shield was triggered by an enemy
        {
            //this.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(rootT.transform.GetComponent<Rigidbody>().velocity.x, 0, 0));
            this.gameObject.GetComponent<Rigidbody>().velocity = rootT.transform.GetComponent<Rigidbody>().velocity;
            this.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0, -10, 0)); 
          


            //Destroy(this.gameObject); //destroy the tiggering gameobject
            anim.SetBool("isDead", true);
            this.transform.parent = rootT; 
            //Enable the Fail Menu
            gameOverCanvas.gameObject.SetActive(true);
            int score;
            int.TryParse(scoreText.GetComponent<Text>().text.ToString(), out score);
            //if (HighScore.S.isHighScore(score))
            //{
            HighScorePlayerPrefs.S.displayScore();
            if (HighScorePlayerPrefs.S.isScore(score)) { 
                // set fail text to say high score 
                submitButton.gameObject.SetActive(true);
                nameField.gameObject.SetActive(true);
                failText.SetText("High Score!");
                Debug.Log("High Score!");
            }

            HighScorePlayerPrefs.S.gameOver = true; 
            //Time.timeScale = 0;
        }
        else
        {
            print("Triggered: " + go.name);
        }


        //print("Triggered: " + go.name); //this is a game testing line
    }
}
