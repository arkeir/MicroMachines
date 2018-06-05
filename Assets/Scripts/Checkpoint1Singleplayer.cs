using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint1Singleplayer : MonoBehaviour
{
    public int rounds;

    [SerializeField]
    private int lapAmount = 3;

    private Player1 player1;
    private SinglePlayerManager updateText;
    

    void Start ()
	{
        player1 = FindObjectOfType<Player1>();
	    updateText = FindObjectOfType<SinglePlayerManager>();
    }


    void OnTriggerEnter(Collider hit)
    {
        if (hit.gameObject.tag == "Player1")
        {
            if (player1.checkpoint1 == false)
            {
                player1.checkpoint1 = true;
                rounds++;
                BoolCheck();
                player1.checkpoint2 = false;
                Debug.Log(rounds);
            }
        }
    }


    void BoolCheck()
    {
        if (rounds == 1)
        {
            updateText.round1 = true;
        }

        else if (rounds == 2)
        {
            updateText.round2 = true;
        }

        else if (rounds == 3)
        {
            updateText.round3 = true;
        }
    }
}
