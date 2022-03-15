using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
  
    //Enemy�� �̵��ӵ�
    [HideInInspector]  public float movespeed = 15f;
    public float startSpeed = 10f;
   
    //enemyPrefab ��������
    public GameObject enemyPrefab;


     //Enemyü�� ����
    public  float enemyHealth;
    private int startenemyHealth = 100;

    //�ӵ��� �����
    public void slowSpeed(float pct)
    {
        movespeed = startSpeed * (1f - pct);
    }

    /*
    40% ���� : startSpeed * (1f- 0.4f)
    40% �ӵ� : starrtSpeed * 0.4f

    ���ݷ� 40% ���� : attack * (1f - 0.4f)
    ���ݷ��� 40% ���� : attack * 0.4f
     */
   
    
    //���� óġ�ϸ� 50G�� ��
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
