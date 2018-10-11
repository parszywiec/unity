using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameSession : MonoBehaviour {

    // config params
    // range w [] pozwoli okreslic co mozna w unity wprowadzic w pole
    // tworzy takze 'slider' w grze zamiast wartosci do wprowadzenia mamy suwak
    [Range(0.1f,10f)][SerializeField] float gameSpeed = 1f;
    [SerializeField] int pointsPerBlockDestoryed = 1;
    [SerializeField] TextMeshProUGUI scoreText;

    // state variable
    [SerializeField] int currentScore = 0;

    private void Awake()
    {
        // zwroc uwage, ze tym razem uzywam findObjectS <- S! , inna funkcja niz zwykle
        int gameStatusCount = FindObjectsOfType<GameSession>().Length;
        if (gameStatusCount > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        // pamietaj pamietaj dodaj tekst do obiektu w unity -> w tym wypadku game status, w ktorym jestesmy
        // w pole textowe wrzocic ScoreText ...
        scoreText.text = currentScore.ToString();
    }

    // Update is called once per frame
    void Update () {
        Time.timeScale = gameSpeed;
    }

    public void addToScore()
    {
        currentScore += pointsPerBlockDestoryed;
        scoreText.text = currentScore.ToString();
    }

    public void DestoryItself()
    {
        Destroy(gameObject);
    }
}
