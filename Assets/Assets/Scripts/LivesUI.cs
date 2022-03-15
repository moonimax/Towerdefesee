using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesUI : MonoBehaviour
{
    public Text LifeShow;


    private void Update()
    {
        LifeShow.text = PlayerStats.Life.ToString() + "LIVES";
    }
}
