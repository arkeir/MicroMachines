using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint2 : MonoBehaviour
{
    private Player1 player1;
    private Player2 player2;


    void Start()
    {
        player1 = FindObjectOfType<Player1>();
        player2 = FindObjectOfType<Player2>();
    }


    void OnTriggerEnter(Collider hit)
    {
        if (hit.gameObject.tag == "Player1")
        {
            if (player1.checkpoint2 == false)
            {
                player1.checkpoint1 = false;
                player1.checkpoint2 = true;
            }
        }

        if (hit.gameObject.tag == "Player2")
        {
            if (player2.checkpoint2 == false)
            {
                player2.checkpoint1 = false;
                player2.checkpoint2 = true;
            }
        }
    }
}