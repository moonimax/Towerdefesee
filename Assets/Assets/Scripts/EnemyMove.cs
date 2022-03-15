using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMove : MonoBehaviour
{
    //이동할 목표 지점
    private Transform target;

    private Enemy enemy;
    

        //points 배열의 인덱스 변수
    private int wayPointsIndex = 0;
    
    
    void Start()
    {
        enemy = this.GetComponent<Enemy>();
            //points 배열의 인덱스 변수 초기화
            wayPointsIndex = 0;

            //WayPoint 클래스의 스태틱 변수 가져와서 target 초기화
            target = WayPoint.points[0];

     
    }

        void Update()
    {
        //[1] 방향 구하기 - Vector3 : 목표위치 - 현재위치
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * Time.deltaTime * enemy.movespeed, Space.World);

        //[2] 목표지점 도착 판정 : 타겟과 자신과의 거리를 구해 도착판정한다
        float dist = Vector3.Distance(transform.position, target.position);

        if (dist <= 0.2f) //거리의 여지를 남긴 이유는 도착 판정을 좀 더 맞게 하기 위함
        {
            GetNextPoint();
        }
        
        //초기 속도로 복원
        enemy.movespeed = enemy.startSpeed;

    }


    //도착시 다음 포인트의 정보를 가져와서 타겟 설정

    private void GetNextPoint()
    {
        //종점 판별해서 도착하면 Enemy 오브젝트 Destroy
        if (wayPointsIndex == WayPoint.points.Length - 1)
        {

            EndPath();
            //실행문. 들어오는 enemy하나에 목숨을 하나 없애야함
            return; //메서드에서 return;을 만나면 메서드 종료
        }
        //Debug.Log($"{wayPointsIndex}번방 도착");
        wayPointsIndex++;
        //Debug.Log($"wayPointsIndex : {wayPointsIndex}");
        target = WayPoint.points[wayPointsIndex];
    }

    public void EndPath()
    {
        PlayerStats.Life--;
        //Debug.Log("종점 도착");
        Destroy(gameObject);
    }

}
