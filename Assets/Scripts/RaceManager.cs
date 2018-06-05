using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceManager : MonoBehaviour
{
    private int roundP1;
    private int roundP2;

    public GameObject P1;
    public GameObject P2;



    void Start()
    {
        roundP1 = FindObjectOfType<Checkpoint1>().roundsPlayer1;
        roundP2 = FindObjectOfType<Checkpoint1>().roundsPlayer2;
    }


    void Update()
    {
    }
}
