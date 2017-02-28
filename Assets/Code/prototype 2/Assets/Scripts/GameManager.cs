using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    [Header ("Player1Variables")]

    public SpinnerScript Player1Spinner;
    public Text Player1ScoreText;

    float Player1Score;


    [Header ("Player2Variables")]

    public SpinnerScript Player2Spinner;
    public Text Player2ScoreText;

    float Player2Score;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        UpdateScore();
        UpdateScoreText();

    }

    void UpdateScore()
    {
        Player1Score = Player2Spinner.points;
        Player2Score = Player1Spinner.points;
    }

    void UpdateScoreText()
    {
        Player1ScoreText.text = Mathf.Round(Player1Score).ToString();
        Player2ScoreText.text = Mathf.Round(Player2Score).ToString();
    }
}
