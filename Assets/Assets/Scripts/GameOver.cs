using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameOver : MonoBehaviour
{
    GameObject gameOver;

    public Text roundsText;
    // Update is called once per frame

    private void OnEnable()
    {
        roundsText.text = PlayerStats.rounds.ToString();
    }


    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); 
    }

    public void Menu()
    {
        Debug.Log("Go to menu");
    }
    
    
    void Update()
    {
        if (PlayerStats.Life == 0) ;

    }
}
