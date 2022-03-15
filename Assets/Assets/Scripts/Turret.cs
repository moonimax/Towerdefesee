using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    //Ÿ��
    private GameObject target;
    private Enemy targetEnemy;

    [Header("Attributes")]
    //�ͷ� ���� ����
    public float attackRange = 15f;
    public GameObject bulletPrefab;
    public Transform firePoint;
    //ȸ������ ������Ʈ ��ü ��������
    public Transform partToRotate;

    //Ÿ�̸� - 0.5��
    //public float timerSearch = 0.5f;
    //private float countdown = 0f;

    //enemy �������� �±�
    [Header("Use Setup Fields")]
    public string enemyTag = "Enemy";

    //�ͷ� ȸ�� �ӵ�
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
    public float damageTimeOver = 30; //�ʴ� ������ 30;

   
    void Start()
    {
        //UpdateTarget �޼��带 0.5�� ���� �ݺ��ؼ� ȣ��
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void Update()
    {
        //enemy�� attackRange.�ȿ� �Ѹ����� �������� ������,  return �ڵ带 �����Ѵ�.
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
        //�߻�Ÿ�̸� - 1��

        else
        {
            if (fireCountdown <= 0f)
            {
                //���๮ - źȯ �߻�
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
        
        //Bullet ��ũ��Ʈ ����
        Bullet bullet = bulletGo.GetComponent<Bullet>();
        bullet.SeekTarget(target.transform);
    }

    private void LockOn()
    {
        //Quaternion(ȸ����)�� �̿�
        Vector3 dir = target.transform.position - partToRotate.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Quaternion targetRotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed);
        Vector3 eulerRotation = targetRotation.eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, eulerRotation.y, 0f);
    }

   
   

    private void Laser()
    {
        //������ ���
       targetEnemy.TakeDamage(damageTimeOver * Time.deltaTime);
       targetEnemy.slowSpeed(slowPct);
        //
        if (!lineRenderer.enabled)
        {
            lineRenderer.enabled = true;
            laserImpacEffect.Play();
            impactLight.enabled = true;
        }
        //������ �� �׸���
        lineRenderer.SetPosition(0, firePoint.position);
        lineRenderer.SetPosition(1, target.transform.position);

        Vector3 dir = firePoint.position - target.transform.position;
        laserImpacEffect.transform.rotation = Quaternion.LookRotation(dir);
        //��ƼŬ
        laserImpacEffect.transform.position = target.transform.position + dir.normalized * .5f;
    }
   
    
    private void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);

        //�ִܰŸ� ���ϴ� �ʱⰪ�� MAX��
        float shortDistance = Mathf.Infinity; //Ȥ�� MaxValue�� ��ü ���� 
        
        //�ִܰŸ��� Enemy
        GameObject nearEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);

            //�Ÿ��� ���ؼ� �ִܰŸ��� �ִ� ���� �Ǻ�
            if(distance < shortDistance) //�ִܰŸ� ���� ���� �Ÿ� ������ ������
            {
                shortDistance = distance;
                nearEnemy = enemy;
            }
        }

        if (nearEnemy != null && shortDistance <= attackRange)
        {
            target = nearEnemy;
            targetEnemy = target.transform.GetComponent<Enemy>();
            //Debug.Log($"�ִܰŸ� : {shortDistance}");
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
