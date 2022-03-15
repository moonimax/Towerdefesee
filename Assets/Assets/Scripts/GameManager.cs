using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool isGameOver = false;

    public GameObject gameoverUI;

   

    void Update()
    {
        if (PlayerStats.Life <= 0)
        {
            isGameOver = true;
            gameoverUI.SetActive(true);
            Debug.Log("GAMEOVER!");
           
        }

        void EndGame()
        {
            isGameOver = true;
            gameoverUI?.SetActive(true);
            Debug.Log("GAME OVER!!!");
        }

        //게임오버 치트키
        if (Input.GetKeyDown(KeyCode.P))
        {
            ShowMeTheMoney();
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            ShowGameOverUI();
        }
    }
    private void ShowMeTheMoney()
    {
        if (!PlayerStats.isCheat)
            return;
        PlayerStats.Addmoney(10000);
    }

    private void ShowGameOverUI()
    {
        gameoverUI.SetActive(true);
        Debug.Log("GAMEOVER!");

    }

}

    
