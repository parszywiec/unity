﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumberWizardCapital : MonoBehaviour {
    [SerializeField] int max, min;
    [SerializeField] Text textZgadywania;
    int guess;

    void Start()
    {
        StartGame();
    }
    void StartGame()
    {
        NextGuess();
    }

    public void OnPressHigher()
    {
        min = guess+1;
        NextGuess();
    }
    public void OnPressLower()
    {
        max = guess-1;
        NextGuess();
    }
    void NextGuess()
    {
        guess = Random.Range(min, max+1);
        textZgadywania.text = guess.ToString();
    }
}
