using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSession : MonoBehaviour {

    [SerializeField] int score;
    [SerializeField] Text scoreText;

    void Awake()
    {
        SetUpSingleton();
    }

    private void Start()
    {
        scoreText.text = score.ToString();
    }

    private void Update()
    {
        scoreText.text = GetScore().ToString();
    }

    private void SetUpSingleton()
    {
        int numberGameSession = FindObjectsOfType<GameSession>().Length;
        if (numberGameSession > 1) Destroy(gameObject);
        else DontDestroyOnLoad(gameObject);
    }

    public void AddToScore(int add)
    {
        score += add;
    }

    public int GetScore()
    {
        return score;
    }

    public void ResetScore()
    {
        Destroy(gameObject);
    }
}
