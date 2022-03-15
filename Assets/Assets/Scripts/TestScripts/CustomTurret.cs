using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomTurret : MonoBehaviour
{
    //Ÿ��
    private GameObject target;

    //�ͷ� ���� ����
    public float attackRange = 15f;

    //Ÿ�̸� - 0.5��
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

    //0.5�ʸ��� ���� ����� ���� ã�� Ÿ�� ��ġ
    private void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);

        //�ִܰŸ� ���ϴ� �ʱⰪ�� MAX��
        shortDistance = Mathf.Infinity; //���� ���Ѵ�

        //�ִܰŸ��� Enemy
        nearEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);

            //�Ÿ��� ���ؼ� �ִܰŸ��� �ִ� ���� �Ǻ�
            if (distance < shortDistance) //�ִܰŸ� ���� ���� �Ÿ� ������ ������
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

            Debug.Log($"�ִܰŸ� : {shortDistance}");
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
