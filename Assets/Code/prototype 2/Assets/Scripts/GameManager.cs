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

    // Sprite Orders
    // 0 = spawners
    // 1 = buckets
    // 2 = moving Buckets
    // 3 = spinners
    // 4 = leaking Buckets
    // 5 = drains
    // 6 = large Tanks
    
    public Sprite[] carnivalSprites;
    public Sprite[] industrialSprites;
    public Sprite[] steampunkSprites;

    float Player2Score;

    // Use this for initialization
    void Start()
    {
        if (PlayerPrefs.GetString("Theme") != "Carnival" || PlayerPrefs.GetString("Theme") != "Carnival" || PlayerPrefs.GetString("Theme") != "Steampunk")
        {
            PlayerPrefs.SetString("Theme", "Carnival");
        }
        SetTheme();
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

    void SetTheme()
    {
        string savedTheme = PlayerPrefs.GetString("Theme");

        GameObject player1Spawner = GameObject.FindGameObjectWithTag("Spawner1");
        GameObject player2Spawner = GameObject.FindGameObjectWithTag("Spawner2");
        GameObject[] buckets = GameObject.FindGameObjectsWithTag("Bucket");
        GameObject[] leakingBuckets = GameObject.FindGameObjectsWithTag("LeakingBucket");
        GameObject[] movingBuckets = GameObject.FindGameObjectsWithTag("MovingBucket");
        GameObject[] spinners = GameObject.FindGameObjectsWithTag("Spinner");
        GameObject[] player1Drains = GameObject.FindGameObjectsWithTag("Player1Refill");
        GameObject[] player2Drains = GameObject.FindGameObjectsWithTag("Player2Refill");
        GameObject[] neutralDrains = GameObject.FindGameObjectsWithTag("Refill");
        GameObject[] LargeTanks = GameObject.FindGameObjectsWithTag("LargeTank");

        if (savedTheme == "Carnival")
        {

            player1Spawner.GetComponent<SpriteRenderer>().sprite = carnivalSprites[0];
            player2Spawner.GetComponent<SpriteRenderer>().sprite = carnivalSprites[0];

            foreach (GameObject bucket in buckets)
            {
                bucket.GetComponent<SpriteRenderer>().sprite = carnivalSprites[1];
            }

            foreach (GameObject movingBucket in movingBuckets)
            {
                movingBucket.GetComponent<SpriteRenderer>().sprite = carnivalSprites[2];
            }

            foreach (GameObject spinner in spinners)
            {
                spinner.GetComponent<SpriteRenderer>().sprite = carnivalSprites[3];
            }

            foreach (GameObject leakingBucket in leakingBuckets)
            {
                leakingBucket.GetComponent<SpriteRenderer>().sprite = carnivalSprites[4];
            }

            foreach (GameObject drain in player1Drains)
            {
                drain.GetComponent<SpriteRenderer>().sprite = carnivalSprites[5];
            }
            foreach (GameObject drain in player2Drains)
            {
                drain.GetComponent<SpriteRenderer>().sprite = carnivalSprites[5];
            }
            foreach (GameObject drain in neutralDrains)
            {
                drain.GetComponent<SpriteRenderer>().sprite = carnivalSprites[5];
            }
            foreach (GameObject largeTank in LargeTanks)
            {
                largeTank.GetComponent<SpriteRenderer>().sprite = carnivalSprites[6];
            }


        }
        else
        if (savedTheme == "Industrial")
        {
            player1Spawner.GetComponent<SpriteRenderer>().sprite = industrialSprites[0];
            player2Spawner.GetComponent<SpriteRenderer>().sprite = industrialSprites[0];

            foreach (GameObject bucket in buckets)
            {
                bucket.GetComponent<SpriteRenderer>().sprite = industrialSprites[1];
            }

            foreach (GameObject movingBucket in movingBuckets)
            {
                movingBucket.GetComponent<SpriteRenderer>().sprite = industrialSprites[2];
            }

            foreach (GameObject spinner in spinners)
            {
                spinner.GetComponent<SpriteRenderer>().sprite = industrialSprites[3];
            }

            foreach (GameObject leakingBucket in leakingBuckets)
            {
                leakingBucket.GetComponent<SpriteRenderer>().sprite = industrialSprites[4];
            }

            foreach (GameObject drain in player1Drains)
            {
                drain.GetComponent<SpriteRenderer>().sprite = industrialSprites[5];
            }
            foreach (GameObject drain in player2Drains)
            {
                drain.GetComponent<SpriteRenderer>().sprite = industrialSprites[5];
            }
            foreach (GameObject drain in neutralDrains)
            {
                drain.GetComponent<SpriteRenderer>().sprite = industrialSprites[5];
            }
            foreach (GameObject largeTank in LargeTanks)
            {
                largeTank.GetComponent<SpriteRenderer>().sprite = industrialSprites[6];
            }
        }
        else
        if (savedTheme == "Steampunk")
        {
            player1Spawner.GetComponent<SpriteRenderer>().sprite = steampunkSprites[0];
            player2Spawner.GetComponent<SpriteRenderer>().sprite = steampunkSprites[0];

            foreach (GameObject bucket in buckets)
            {
                bucket.GetComponent<SpriteRenderer>().sprite = steampunkSprites[1];
            }

            foreach (GameObject movingBucket in movingBuckets)
            {
                movingBucket.GetComponent<SpriteRenderer>().sprite = steampunkSprites[2];
            }

            foreach (GameObject spinner in spinners)
            {
                spinner.GetComponent<SpriteRenderer>().sprite = steampunkSprites[3];
            }

            foreach (GameObject leakingBucket in leakingBuckets)
            {
                leakingBucket.GetComponent<SpriteRenderer>().sprite = steampunkSprites[4];
            }

            foreach (GameObject drain in player1Drains)
            {
                drain.GetComponent<SpriteRenderer>().sprite = steampunkSprites[5];
            }
            foreach (GameObject drain in player2Drains)
            {
                drain.GetComponent<SpriteRenderer>().sprite = steampunkSprites[5];
            }
            foreach (GameObject drain in neutralDrains)
            {
                drain.GetComponent<SpriteRenderer>().sprite = steampunkSprites[5];
            }
            foreach (GameObject largeTank in LargeTanks)
            {
                largeTank.GetComponent<SpriteRenderer>().sprite = steampunkSprites[6];
            }
        }
    }

    public void testThemeSwitch()
    {
        string savedTheme = PlayerPrefs.GetString("Theme");

        if( savedTheme == "Carnival" )
        {
            PlayerPrefs.SetString("Theme", "Industrial");
            SetTheme();
        }
        if (savedTheme == "Industrial")
        {
            PlayerPrefs.SetString("Theme", "Steampunk");
            SetTheme();
        }
        if (savedTheme == "Steampunk")
        {
            PlayerPrefs.SetString("Theme", "Carnival");
            SetTheme();
        }
    }
}
