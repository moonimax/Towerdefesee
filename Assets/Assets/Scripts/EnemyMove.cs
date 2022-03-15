using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMove : MonoBehaviour
{
    //�̵��� ��ǥ ����
    private Transform target;

    private Enemy enemy;
    

        //points �迭�� �ε��� ����
    private int wayPointsIndex = 0;
    
    
    void Start()
    {
        enemy = this.GetComponent<Enemy>();
            //points �迭�� �ε��� ���� �ʱ�ȭ
            wayPointsIndex = 0;

            //WayPoint Ŭ������ ����ƽ ���� �����ͼ� target �ʱ�ȭ
            target = WayPoint.points[0];

     
    }

        void Update()
    {
        //[1] ���� ���ϱ� - Vector3 : ��ǥ��ġ - ������ġ
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * Time.deltaTime * enemy.movespeed, Space.World);

        //[2] ��ǥ���� ���� ���� : Ÿ�ٰ� �ڽŰ��� �Ÿ��� ���� ���������Ѵ�
        float dist = Vector3.Distance(transform.position, target.position);

        if (dist <= 0.2f) //�Ÿ��� ������ ���� ������ ���� ������ �� �� �°� �ϱ� ����
        {
            GetNextPoint();
        }
        
        //�ʱ� �ӵ��� ����
        enemy.movespeed = enemy.startSpeed;

    }


    //������ ���� ����Ʈ�� ������ �����ͼ� Ÿ�� ����

    private void GetNextPoint()
    {
        //���� �Ǻ��ؼ� �����ϸ� Enemy ������Ʈ Destroy
        if (wayPointsIndex == WayPoint.points.Length - 1)
        {

            EndPath();
            //���๮. ������ enemy�ϳ��� ����� �ϳ� ���־���
            return; //�޼��忡�� return;�� ������ �޼��� ����
        }
        //Debug.Log($"{wayPointsIndex}���� ����");
        wayPointsIndex++;
        //Debug.Log($"wayPointsIndex : {wayPointsIndex}");
        target = WayPoint.points[wayPointsIndex];
    }

    public void EndPath()
    {
        PlayerStats.Life--;
        //Debug.Log("���� ����");
        Destroy(gameObject);
    }

}
