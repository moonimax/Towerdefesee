using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //enemy의 위치를 가져옴
    private Transform target;

    //이동 속도
    public float moveSpeed = 70f;
    public float explosionRadius = 0f;

    public GameObject ImpactBullet;

    public Transform missilePartToRotate;

    public int damage = 50;

    

    Enemy enemy;

    //터렛의 Lock On된 타겟을 탄환의 타겟으로 가져온다
    public void SeekTarget(Transform _target)
    {
        target = _target; //private target을 사용할 수 있게 만듦
    }

    private void Update()
    {
        //타겟이 없어지면, 다른 탄환에 의해 죽을 때 사용
        //목표한 타겟이 사라지면 탄환 처리(킬)
        if (target == null) //불릿이 이미 파괴된 적을 가는 것을 방지
        {
            Destroy(gameObject);
            return;
        }

        //타겟으로 탄환을 이동시킨다
        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = Time.deltaTime * moveSpeed; //이동할 거리

        //타겟까지의 거리가 현재 프레임에서 이동할 거리보다 작으면 충돌판정
        if (dir.magnitude < distanceThisFrame) //거리이용 판정보다 정밀함
        {
            HitTarget();
            return;
        }


        transform.Translate(dir.normalized * Time.deltaTime * moveSpeed, Space.World);
        transform.LookAt(target);

       
    }

    private void HitTarget()
    {
        Debug.Log("Hit Target");
       

        if (explosionRadius > 0f)
        {
            Explode();
            GameObject expl = (GameObject)Instantiate(ImpactBullet, transform.position, transform.rotation);
            Destroy(expl, 3f);

        }

        else
        {
            Damage(target);
            
                 GameObject expl = (GameObject)Instantiate(ImpactBullet, transform.position, transform.rotation);
                 Destroy(expl, 3f);
            
        }

        //enemy 체력을 계산하고 없애는 과정     
        Destroy(gameObject);

    }


    void Explode()
    {
        Collider[] hitcolliders = Physics.OverlapSphere(transform.position, 7.0f);

        foreach (Collider collider in hitcolliders)
        {
            if (collider.tag == "Enemy")
            {
                //여기선 gameObject가 미사일탄환이기때문에 이걸 없애면 안된다.
                Damage(collider.transform);
            }

        }

    }
    void Damage(Transform enemy)
    {
        Enemy e = enemy.GetComponent<Enemy>();

        if (e != null)
        {
            e.TakeDamage(damage);
                
        }

    }
}



   
