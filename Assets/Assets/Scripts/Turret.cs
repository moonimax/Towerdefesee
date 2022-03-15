using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    //타겟
    private GameObject target;
    private Enemy targetEnemy;

    [Header("Attributes")]
    //터렛 공격 범위
    public float attackRange = 15f;
    public GameObject bulletPrefab;
    public Transform firePoint;
    //회전관리 오브젝트 객체 가져오기
    public Transform partToRotate;

    //타이머 - 0.5초
    //public float timerSearch = 0.5f;
    //private float countdown = 0f;

    //enemy 프리팹의 태그
    [Header("Use Setup Fields")]
    public string enemyTag = "Enemy";

    //터렛 회전 속도
    public float turnSpeed = 10f;

    [Header("Use Bullets(default)")]
    public float timeFire = 1f;
    private float fireCountdown = 0f;

    [Header("Use Laser")]
    public bool useLaser = false;
    public LineRenderer lineRenderer;
    public ParticleSystem laserImpacEffect;
    public Light impactLight;
    
    public float slowPct = 0.4f;
    public float damageTimeOver = 30; //초당 데미지 30;

   
    void Start()
    {
        //UpdateTarget 메서드를 0.5초 마다 반복해서 호출
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void Update()
    {
        //enemy가 attackRange.안에 한마리도 존재하지 않을때,  return 코드를 실행한다.
        if (target == null)
        {
           if(useLaser)
            {
                if (lineRenderer.enabled)
                    lineRenderer.enabled = false;
                    laserImpacEffect.Stop();
                    impactLight.enabled = false;
            }
            return;
        }
        LockOn();


        //lock on
        //LockOn();
        if (useLaser)
        {
            Laser();
        }
        //발사타이머 - 1초

        else
        {
            if (fireCountdown <= 0f)
            {
                //실행문 - 탄환 발사
                Shoot();

                fireCountdown = timeFire;
            }
            fireCountdown -= Time.deltaTime;
        }
    }

    private void Shoot()
    {
        Debug.Log("Shoot!!!");
        GameObject bulletGo = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        
        //Bullet 스크립트 접근
        Bullet bullet = bulletGo.GetComponent<Bullet>();
        bullet.SeekTarget(target.transform);
    }

    private void LockOn()
    {
        //Quaternion(회전값)을 이용
        Vector3 dir = target.transform.position - partToRotate.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Quaternion targetRotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed);
        Vector3 eulerRotation = targetRotation.eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, eulerRotation.y, 0f);
    }

   
   

    private void Laser()
    {
        //데미지 계산
       targetEnemy.TakeDamage(damageTimeOver * Time.deltaTime);
       targetEnemy.slowSpeed(slowPct);
        //
        if (!lineRenderer.enabled)
        {
            lineRenderer.enabled = true;
            laserImpacEffect.Play();
            impactLight.enabled = true;
        }
        //레이저 빔 그리기
        lineRenderer.SetPosition(0, firePoint.position);
        lineRenderer.SetPosition(1, target.transform.position);

        Vector3 dir = firePoint.position - target.transform.position;
        laserImpacEffect.transform.rotation = Quaternion.LookRotation(dir);
        //파티클
        laserImpacEffect.transform.position = target.transform.position + dir.normalized * .5f;
    }
   
    
    private void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);

        //최단거리 구하는 초기값은 MAX값
        float shortDistance = Mathf.Infinity; //혹은 MaxValue로 대체 가능 
        
        //최단거리의 Enemy
        GameObject nearEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);

            //거리를 비교해서 최단거리에 있는 적을 판별
            if(distance < shortDistance) //최단거리 값이 기존 거리 값보다 작으면
            {
                shortDistance = distance;
                nearEnemy = enemy;
            }
        }

        if (nearEnemy != null && shortDistance <= attackRange)
        {
            target = nearEnemy;
            targetEnemy = target.transform.GetComponent<Enemy>();
            //Debug.Log($"최단거리 : {shortDistance}");
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
