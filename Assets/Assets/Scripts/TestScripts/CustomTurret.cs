using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomTurret : MonoBehaviour
{
    //타겟
    private GameObject target;

    //터렛 공격 범위
    public float attackRange = 15f;

    //타이머 - 0.5초
    public float timerSearch = 0.5f;
    

    //
    public string enemyTag = "Enemy";

    public GameObject head;

    float shortDistance;

    GameObject nearEnemy;

    void Start()
    {
        InvokeRepeating("UpdateTarget", 0.5f, 0.5f);
    }

    //0.5초마다 가장 가까운 적을 찾아 타겟 서치
    private void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);

        //최단거리 구하는 초기값은 MAX값
        shortDistance = Mathf.Infinity; //양의 무한대

        //최단거리의 Enemy
        nearEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);

            //거리를 비교해서 최단거리에 있는 적을 판별
            if (distance < shortDistance) //최단거리 값이 기존 거리 값보다 작으면
            {
                shortDistance = distance;
                nearEnemy = enemy;
            }
        }

        
    }
    void Update()
    {

        if (nearEnemy != null && shortDistance <= attackRange)
        {
            target = nearEnemy;

            Vector3 dir = target.transform.position - head.transform.position;
            Quaternion targetRotation = Quaternion.LookRotation(dir);
            Vector3 lookRotation = Quaternion.Lerp(head.transform.rotation, targetRotation, Time.deltaTime * 10f).eulerAngles;            
            head.transform.rotation = Quaternion.Euler(0f, lookRotation.y, 0f);

            Debug.Log($"최단거리 : {shortDistance}");
        }

        else
        {
            target = null;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
