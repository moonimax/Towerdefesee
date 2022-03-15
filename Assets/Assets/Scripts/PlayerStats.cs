using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



[System.Serializable]
public class PlayerStats : MonoBehaviour
{
    public static bool isCheat = false;
    public static int money;
    public int startMoney = 400;
    //Botton UI ������ ����
    public Text MyMoney;
   
    
    //�÷��̾��� ���
    public static int Life;
    public int startLife = 10;

    public static int rounds = 0;


    private void Awake()
    {
        money = startMoney;
        Life = startLife;
    }

    public static void Addmoney(int amount)
    {
        money += amount;
    }

    /*
    public static bool UseMoney(int amount)
    {
        if(money < amount)
            return false;
    }
    */
    public static bool HasMoney(int amount)
    {
        return money >= amount;
    }
    /*
    public static bool UseMoney(int amount)
    {
        if(money < amount)
            return false;
    }
    */
}