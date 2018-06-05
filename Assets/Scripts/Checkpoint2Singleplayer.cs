using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint2Singleplayer : MonoBehaviour {

    private Player1 player1;


    void Start ()
    {
        player1 = FindObjectOfType<Player1>();
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
    }
}
