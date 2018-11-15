using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Assertions;

public class GameplayUI : MonoBehaviour {

    [SerializeField] private TextMeshProUGUI scoreLabel;

    private void Awake()
    {
        Assert.IsNotNull(scoreLabel);
    }

    void Update () {
        var scoreAsInt = (int)GameManager.Instance.Score;
        scoreLabel.text = scoreAsInt.ToString();
	}
}
