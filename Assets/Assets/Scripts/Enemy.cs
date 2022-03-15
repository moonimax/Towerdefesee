using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
  
    //Enemy의 이동속도
    [HideInInspector]  public float movespeed = 15f;
    public float startSpeed = 10f;
   
    //enemyPrefab 가져오기
    public GameObject enemyPrefab;


     //Enemy체력 설정
    public  float enemyHealth;
    private int startenemyHealth = 100;

    //속도를 늦춘다
    public void slowSpeed(float pct)
    {
        movespeed = startSpeed * (1f - pct);
    }

    /*
    40% 감속 : startSpeed * (1f- 0.4f)
    40% 속도 : starrtSpeed * 0.4f

    공격력 40% 감소 : attack * (1f - 0.4f)
    공격력의 40% 적용 : attack * 0.4f
     */
   
    
    //적을 처치하면 50G를 줌
    public int value = 50;

    void Start()
    {
        enemyHealth = startenemyHealth;
        movespeed = startSpeed;
    }
    public void TakeDamage(float damage)
    {
        enemyHealth -= damage;
        if(enemyHealth <= 0)
        {
            Die();
        }

        void Die()
        {
            PlayerStats.money += value;
            Destroy(gameObject);
        }
    }
    void Update()
    {
        
        
    }
 
    
   
    

   
}
