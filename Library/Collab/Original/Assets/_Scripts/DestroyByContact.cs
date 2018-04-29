using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class DestroyByContact : MonoBehaviour
{

    private GameObject lastTriggeredGo;

    public GameObject failText;
    public Text scoreText;
    public InputField nameField;
    public Button submitButton; 
    public Text nameText; 

    public Canvas gameOverCanvas;

    public static Animator anim;

    void Start()
    {
        //make sure the Fail Menu is not enabled
        gameOverCanvas.gameObject.SetActive(false);

        // Activating AnimatorController
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
            // Setting an animation bool to true to play death animation.
            anim.SetBool("isDead", true);
            // Setting albatross to be child of rootT for GC.
            this.transform.parent = rootT;


            //Enable the Fail Menu
            gameOverCanvas.gameObject.SetActive(true);
            int score;
            int.TryParse(scoreText.GetComponent<Text>().text.ToString(), out score); 
            if (HighScore.S.isHighScore(score))
            {
                // set fail text to say high score 
                submitButton.gameObject.SetActive(true);
                nameField.gameObject.SetActive(true);
                Debug.Log("High Score!"); 
            }

        }
        else
        {
            print("Triggered: " + go.name);
        }

    }

}
