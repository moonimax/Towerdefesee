using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrawSurvivedRoundsUI : MonoBehaviour
{
    public Text roundsText;
    
    void Update()
    {
        roundsText.text = PlayerStats.rounds.ToString();
    }
}
