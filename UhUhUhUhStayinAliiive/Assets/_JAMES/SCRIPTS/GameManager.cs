using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public AudioSource music;

    public bool startPlaying;

    public BeatScroller theBS;

    public static GameManager instance;

    public int currentScore;
    public int scorePerNote = 100;
    public int currentMultiplier;
    public int multiplierTracker;
    public int[] multiplierThresholds;

    public Text scoreText;
    public Text multiplierText;



    // Start is called before the first frame update
    void Start()
    {
        instance = this; //I BELIEVE THIS MAKES THE GAMEMANAGER A SINGLETON?

        scoreText.text = "Score: 0";

        currentMultiplier = 1;
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
        


    }

    public void NoteHit()
    {
        Debug.Log("Note hit!");

        if (currentMultiplier - 1 < multiplierThresholds.Length)
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

        currentScore += scorePerNote * currentMultiplier;
        scoreText.text = "Score: " + currentScore;

    }

    public void NoteMiss()
    {
        Debug.Log("Missed note bich");

        currentMultiplier = 1;
        multiplierTracker = 0;

        multiplierText.text = "Multiplier: x" + currentMultiplier;

        // currentScore -= scorePerNote;
        // scoreText.text = "Score: " + currentScore;
    }





    // END OF FILE
}
