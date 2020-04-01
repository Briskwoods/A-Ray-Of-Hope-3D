using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{

    public int currentLetters; // Number of letters player has collected
    public Text letters;
    public int totalLetters; //total number of letters in the level
    private int maxLetters;
    public GameObject door;
    public GameObject doorPosition;
    public GameObject endConvoTrigger;
    public PlayerController Player;

   

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per framehybjm
    void Update()
    {

        if (letters.text == "Letters: 7/7" || letters.text == "Letters: 4/4")
        {
            endConvoTrigger.transform.position = Player.transform.position;
        }
    }

    public void AddLetter(int letterToAdd)
    {

        currentLetters += letterToAdd;
        letters.text = "Letters: " + currentLetters + "/"+totalLetters;

        if (letters.text == "Letters: 7/7" || letters.text == "Letters: 4/4")
        {
            Instantiate(door, doorPosition.transform.position, doorPosition.transform.rotation);
            //Instantiate(endConvoTrigger, Player.transform.position, Player.transform.rotation);
            
        }
    }  
}
