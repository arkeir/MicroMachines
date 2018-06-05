using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint1 : MonoBehaviour
{
    public int roundsPlayer1;
    public int roundsPlayer2;


    private int lapAmount = 3;
    
    private Player1 player1;
    private Player2 player2;
    private RaceClock updateText;


    void Start()
    {
        player1 = FindObjectOfType<Player1>();
        player2 = FindObjectOfType<Player2>();
        updateText = FindObjectOfType<RaceClock>();
    }


    void OnTriggerEnter(Collider hit)
    {
        if (hit.gameObject.tag == "Player1")
        {
            if (player1.checkpoint1 == false)
            {
                player1.checkpoint1 = true;
                roundsPlayer1++;
                BoolCheckP1();
                player1.checkpoint2 = false;
                Debug.Log(roundsPlayer1);
            }
        }

        if (hit.gameObject.tag == "Player2")
        {
            if (player2.checkpoint1 == false)
            {
                player2.checkpoint1 = true;
                roundsPlayer2++;
                BoolCheckP2();
                player2.checkpoint2 = false;
                Debug.Log(roundsPlayer2);
            }
        }
    }


    void BoolCheckP1()
    {
        if (roundsPlayer1 == 1)
        {
            updateText.round1_P1 = true;

        }

        else if (roundsPlayer1 == 2)
        {
            updateText.round2_P1 = true;
        }

        else if (roundsPlayer1 == 3)
        {
            updateText.round3_P1 = true;
        }
    }


    void BoolCheckP2()
    {
        if (roundsPlayer2 == 1)
        {
            updateText.round1_P2 = true;
        }

        else if (roundsPlayer2 == 2)
        {
            updateText.round2_P2 = true;
        }

        else if (roundsPlayer2 == 3)
        {
            updateText.round3_P2 = true;
        }
    }
}
