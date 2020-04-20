using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public AudioSource music;

    public bool startPlaying;

    public BeatScroller theBS;

    public static GameManager instance;

    public int currentScore;
    public int scorePerNote = 100;
    public int scorePerGoodNote = 125;
    public int scorePerPerfectNote = 150;
    public int Lives = 10;

    public int currentMultiplier;
    public int multiplierTracker;
    public int[] multiplierThresholds;

    public Text scoreText;
    public Text multiplierText;
    public Text livesText;

    public float totalNotes;
    public float normalHits;
    public float goodHits;
    public float perfectHits;
    public float missedHits;

    public GameObject resultsScreen;
    public Text percentageHitText, normalsText, goodsText, perfectsText, missesText, rankText, finalScoreText;





    // Start is called before the first frame update
    void Start()
    {
        instance = this; //I BELIEVE THIS MAKES THE GAMEMANAGER A SINGLETON?

        scoreText.text = "Score: 0"; // INITIALIZE THE SCORE TEXT AT 0

        currentMultiplier = 1;

        // FIND THE TOTAL NOTES IN THE SCENE
        totalNotes = FindObjectsOfType<NoteCheck>().Length;

    }

    // Update is called once per frame
    void Update()
    {
        if (!startPlaying)
        {
            if (Input.anyKeyDown)
            {
                startPlaying = true;
                theBS.hasStarted = true;

                music.Play();
            }
        }
        else
        {
            // IF THE MUSIC HAS STOPPED AND THE RESULTS SCREEN IS NOT YET ACTIVE
            if (!music.isPlaying && !resultsScreen.activeInHierarchy)
            {
                resultsScreen.SetActive(true); // THEN ACTIVATE THE RESULTS SCREEN

                // DISPLAY THE SCORE AND RANKINGS
                normalsText.text = normalHits.ToString();
                goodsText.text = goodHits.ToString();
                perfectsText.text = perfectHits.ToString();
                missesText.text = missedHits.ToString();

                float totalHit = normalHits + goodHits + perfectHits;
                float percentageHit = (totalHit / totalNotes) * 100;
                percentageHitText.text = percentageHit.ToString("F1") + "%";

                string rankValue = "F";

                if (percentageHit > 40)
                {
                    rankValue = "D";
                    if (percentageHit > 55)
                    {
                        rankValue = "C";
                        if (percentageHit > 70)
                        {
                            rankValue = "B";
                            if (percentageHit > 85)
                            {
                                rankValue = "A";
                                if (percentageHit > 95)
                                {
                                    rankValue = "S";
                                    Lives++;
                                }
                            }
                        }
                    }

                }

                rankText.text = rankValue;

                finalScoreText.text = currentScore.ToString();

            }

        }
    }

    public void NoteHit()
    {
        Debug.Log("Note hit!");

        if (currentMultiplier - 1 < multiplierThresholds.Length) // ENSURES THE CURRENT MULTIPLYER DOES NOT EXCEED THE LENGTH OF OUR MULTIPLYER THREHOLD ARRAY
        {
            multiplierTracker++; // EACH NOTE HIT WE ADD ONE TO OUR MULTIPLIER TRACKER

            // IF THE TRACKER EXCEEDS THE MULTIPLIER THRESHOLD THEN RESET THE TRACKER AND ADD TO THE MULTIPLIER
            if (multiplierThresholds[currentMultiplier - 1] <= multiplierTracker)
            {
                multiplierTracker = 0;
                currentMultiplier++;
            }

        }

        multiplierText.text = "Multiplier: x" + currentMultiplier;

        scoreText.text = "Score: " + currentScore;

    }

    public void NoteMiss()
    {
        Debug.Log("Missed note bich");

        currentMultiplier = 1;
        multiplierTracker = 0;

        multiplierText.text = "Multiplier: x" + currentMultiplier;

        missedHits++; // KEEPING TRACK OF OUR TOTAL MISSES

        // currentScore -= scorePerNote;
        // scoreText.text = "Score: " + currentScore;
    }

    public void NormalHit()
    {
        currentScore += scorePerNote * currentMultiplier;

        NoteHit();
        normalHits++; // KEEPING TRACK OF OUR TOTAL NORMAL HITS

    }

    public void GoodHit()
    {
        currentScore += scorePerGoodNote * currentMultiplier;

        NoteHit();
        goodHits++; // KEEPING TRACK OF OUR TOTAL GUCCI HITS

    }

    public void PerfectHit()
    {
        currentScore += scorePerPerfectNote * currentMultiplier;

        NoteHit();
        perfectHits++; // KEEPING TRACK OF OUR TOTAL PERFECT HITS

    }

    public void ProcessPlayerDeath()
    {
        if (Lives > 1)
        {
            TakeLife();
        }
        else
        {
            ResetGameSession();
        }

    }

    void ResetGameSession()
    {
        // DELETE THE GAMESESSION OBJECT AND START FROM THE MAIN MENU
        SceneManager.LoadScene(0);
        Destroy(gameObject);

    }

    void TakeLife()
    {
        // REDUCE LIVES BY ONE
        Lives--;

        livesText.text = "Lives: " + Lives;

    }





    // END OF FILE
}
