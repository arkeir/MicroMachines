using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System;
using JetBrains.Annotations;

public class RaceClock : MonoBehaviour
{
    public float seconds, minutes, milliSeconds;

    public bool round1_P1 = false;
    public bool round2_P1 = false;
    public bool round3_P1 = false;

    public bool round1_P2 = false;
    public bool round2_P2 = false;
    public bool round3_P2 = false;

    public Text round1_txt_P1;
    public Text round2_txt_P1;
    public Text round3_txt_P1;

    public Text round1_txt_P2;
    public Text round2_txt_P2;
    public Text round3_txt_P2;

    public Text raceClock;

    public Text firstPlace;
    public Text firstPlaceTime;

    public Text secondPlace;

    public Canvas GameCanvas;
    public Canvas endGameCanvas;
    public Canvas PauseMenuCanvas;


    private bool finish_P1 = false;
    private bool finish_P2 = false;
    

    void Update()
    {
        LapTimeP1();
        LapTimeP2();

        minutes = (int) (Time.timeSinceLevelLoad / 60f);
        seconds = (int) (Time.timeSinceLevelLoad % 60f);
        milliSeconds = (int) (Time.timeSinceLevelLoad % 1*60);
        raceClock.GetComponent<Text>().text = minutes.ToString("00") + ":" + seconds.ToString("00") + ":" + milliSeconds.ToString("00");

        if (Input.GetKeyDown(KeyCode.P))
        {
            Pause();
        }
    }


    public void Resume()
    {
        Time.timeScale = 1;
        GameCanvas.gameObject.SetActive(true);
        PauseMenuCanvas.gameObject.SetActive(false);
    }


    void Pause()
    {
        if (GameCanvas.gameObject.activeInHierarchy)
        {
            Time.timeScale = 0;
            GameCanvas.gameObject.SetActive(false);
            PauseMenuCanvas.gameObject.SetActive(true);
        }

        else
        {
            Resume();
        }
    }


    void WinScreen()
    {
        Time.timeScale = 0;
        endGameCanvas.gameObject.SetActive(true);
        GameCanvas.gameObject.SetActive(false);

        if (finish_P1 == false)
        {
            firstPlace.GetComponent<Text>().text = "Player 1 won the race!";
            firstPlaceTime.GetComponent<Text>().text = "with the time of " + minutes.ToString("00") + ":" + seconds.ToString("00") + ":" + milliSeconds.ToString("00");
            secondPlace.GetComponent<Text>().text = "Second place is Player 2";
        }

        if (finish_P2 == false)
        {
            firstPlace.GetComponent<Text>().text = "Player 2 won the race!";
            firstPlaceTime.GetComponent<Text>().text = "With the time of " + minutes.ToString("00") + ":" + seconds.ToString("00") + ":" + milliSeconds.ToString("00");
            secondPlace.GetComponent<Text>().text = "Second place is Player 1";
        }
    }

    
    void LapTimeP1()
    {
        if (round1_P1 == true)
        {
            round1_txt_P1.GetComponent<Text>().text = minutes.ToString("00") + ":" + seconds.ToString("00") + ":" + milliSeconds.ToString("00");
            round1_P1 = false;
        }

        if (round2_P1 == true)
        {
            round2_txt_P1.GetComponent<Text>().text = minutes.ToString("00") + ":" + seconds.ToString("00") + ":" + milliSeconds.ToString("00");
            round2_P1 = false;
        }

        if (round3_P1 == true)
        {
            round3_txt_P1.GetComponent<Text>().text = minutes.ToString("00") + ":" + seconds.ToString("00") + ":" + milliSeconds.ToString("00");
            round3_P1 = false;

            if (finish_P1 == false)
            {
                finish_P2 = true;
                WinScreen();
            }
        }
    }


    void LapTimeP2()
    {
        if (round1_P2 == true)
        {
            round1_txt_P2.GetComponent<Text>().text = minutes.ToString("00") + ":" + seconds.ToString("00") + ":" + milliSeconds.ToString("00");
            round1_P2 = false;
        }

        if (round2_P2 == true)
        {
            round2_txt_P2.GetComponent<Text>().text = minutes.ToString("00") + ":" + seconds.ToString("00") + ":" + milliSeconds.ToString("00");
            round2_P2 = false;
        }

        if (round3_P2 == true)
        {
            round3_txt_P2.GetComponent<Text>().text = minutes.ToString("00") + ":" + seconds.ToString("00") + ":" + milliSeconds.ToString("00");
            round3_P2 = false;

            if (finish_P2 == false)
            {
                finish_P1 = true;
                WinScreen();
            }
        }
    }
}
