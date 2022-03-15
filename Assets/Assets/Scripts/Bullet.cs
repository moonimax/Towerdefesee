using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //enemy�� ��ġ�� ������
    private Transform target;

    //�̵� �ӵ�
    public float moveSpeed = 70f;
    public float explosionRadius = 0f;

    public GameObject ImpactBullet;

    public Transform missilePartToRotate;

    public int damage = 50;

    

    Enemy enemy;

    //�ͷ��� Lock On�� Ÿ���� źȯ�� Ÿ������ �����´�
    public void SeekTarget(Transform _target)
    {
        target = _target; //private target�� ����� �� �ְ� ����
    }

    private void Update()
    {
        //Ÿ���� ��������, �ٸ� źȯ�� ���� ���� �� ���
        //��ǥ�� Ÿ���� ������� źȯ ó��(ų)
        if (target == null) //�Ҹ��� �̹� �ı��� ���� ���� ���� ����
        {
            Destroy(gameObject);
            return;
        }

        //Ÿ������ źȯ�� �̵���Ų��
        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = Time.deltaTime * moveSpeed; //�̵��� �Ÿ�

        //Ÿ�ٱ����� �Ÿ��� ���� �����ӿ��� �̵��� �Ÿ����� ������ �浹����
        if (dir.magnitude < distanceThisFrame) //�Ÿ��̿� �������� ������
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

        //enemy ü���� ����ϰ� ���ִ� ����     
        Destroy(gameObject);

    }


    void Explode()
    {
        Collider[] hitcolliders = Physics.OverlapSphere(transform.position, 7.0f);

        foreach (Collider collider in hitcolliders)
        {
            if (collider.tag == "Enemy")
            {
                //���⼱ gameObject�� �̻���źȯ�̱⶧���� �̰� ���ָ� �ȵȴ�.
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



   
