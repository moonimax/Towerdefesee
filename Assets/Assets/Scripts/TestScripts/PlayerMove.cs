using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Transform target;

    public float moveSpeed = 10f;
    public float turnSpeed = 10f; 

    float x;

    void Start()
    {
        
    }

    void Update()
    {
        Vector3 dir = target.position - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(dir);
        Quaternion lookRotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * turnSpeed);
        Vector3 eRotation = lookRotation.eulerAngles;
        transform.rotation = Quaternion.Euler(0, eRotation.y, 0);

        //transform.rotation = targetRotation;

        /*
        x += Time.deltaTime * 10;
        transform.rotation = Quaternion.Euler(0, x, 0);
        */

        /*
        캡슐이 내려가면서 이동하는 것을 방지하는 법
        Vector3 targetPosition = new Vector3(target.position.x, 1.5f, target.position.z);
        Vector3 dir = targetPosition - transform.position;
        transform.Translate(dir.normalized * Time.deltaTime * moveSpeed, Space.World);
        */

        //실시간 이동 코드
        //transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.Self);
        //transform.Translate(Vector3.back * Time.deltaTime, Space.World);
        //transform.Translate(Vector3.right * Time.deltaTime, Space.Self);
        //transform.Translate(Vector3.left * Time.deltaTime, Space.World);
        //transform.Translate(Vector3.up * Time.deltaTime, Space.World);
        //transform.Translate(Vector3.down * Time.deltaTime, Space.World);
    }
}
