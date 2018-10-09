using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberWizardCapital : MonoBehaviour {
    int max = 1000, min = 1, guess = 500;
    // Use this for initialization
    void Start () {
        //int max = 1000, min = 1, guess = 500;
        StartGame();

    }
	
    void StartGame()
    {
        max = 1000; min = 1; guess = 500;

        Debug.Log("Welcom to number wizard");
        Debug.Log("Pick Number");
        Debug.Log("Highest number is: " + max);
        Debug.Log("Lowest number is: " + min);
        Debug.Log("Tell me if your number is higher or lower then " + guess);
        Debug.Log("Push up = higher, push down = lower, enter = correct");
        max = max + 1;
    }

	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Debug.Log("number is higher then "+guess);
            min = guess;
            NextGuess();
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Debug.Log("number is lower then "+guess);
            max = guess;
            NextGuess();
        }
        else if (Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log(guess+" is the number");
            StartGame();
        }
        

    }
    void NextGuess()
    {
        guess = (max + min) / 2;
        Debug.Log("is it " + guess + "?");
    }
}
