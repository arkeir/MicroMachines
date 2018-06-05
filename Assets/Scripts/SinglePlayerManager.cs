using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SinglePlayerManager : MonoBehaviour {

    public float seconds, minutes, milliSeconds;

    public bool round1 = false;
    public bool round2 = false;
    public bool round3 = false;
    
    public Text round1_txt;
    public Text round2_txt;
    public Text round3_txt;
    public Text finishTime;
    public Text raceClock;

    public Canvas GameCanvas;
    public Canvas endGameCanvas;
    public Canvas PauseMenuCanvas;
    
	
	void Update () {

	    minutes = (int)(Time.timeSinceLevelLoad / 60f);
	    seconds = (int)(Time.timeSinceLevelLoad % 60f);
	    milliSeconds = (int)(Time.timeSinceLevelLoad % 1 * 60);
	    raceClock.GetComponent<Text>().text = minutes.ToString("00") + ":" + seconds.ToString("00") + ":" + milliSeconds.ToString("00");

        LapTime();

	    if (Input.GetKeyDown(KeyCode.P))
	    {
	        Pause();
	    }
    }


    void WinScreen()
    {
        Time.timeScale = 0;
        endGameCanvas.gameObject.SetActive(true);
        GameCanvas.gameObject.SetActive(false);

        finishTime.GetComponent<Text>().text = "Your time is: " + minutes.ToString("00") + ":" + seconds.ToString("00") + ":" + milliSeconds.ToString("00");
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


    void LapTime()
    {
        if (round1 == true)
        {
            round1_txt.GetComponent<Text>().text = minutes.ToString("00") + ":" + seconds.ToString("00") + ":" + milliSeconds.ToString("00");
            round1 = false;
        }

        if (round2 == true)
        {
            round2_txt.GetComponent<Text>().text = minutes.ToString("00") + ":" + seconds.ToString("00") + ":" + milliSeconds.ToString("00");
            round2 = false;
        }

        if (round3 == true)
        {
            round3_txt.GetComponent<Text>().text = minutes.ToString("00") + ":" + seconds.ToString("00") + ":" + milliSeconds.ToString("00");
            round3 = false;
            
            WinScreen();
        }
    }
}
