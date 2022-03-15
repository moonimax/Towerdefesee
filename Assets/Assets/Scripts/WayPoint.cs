using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//WayPoint ����(��ġ ����)�� �����´�.
public class WayPoint : MonoBehaviour
{
    //WayPoint�� Transform �迭���� ����
    public static Transform[] points; //�������� ���

    private void Awake()
    {
        //transform�� �ڽ� ������Ʈ ������ �����ͼ� points �迭 �� ����
        points = new Transform[this.transform.childCount];

        //points �迭 �渶�� �ڽ� ������Ʈ�� transform���� �ʱ�ȭ
        for (int i = 0; i < points.Length; i++)
        {
            points[i] = transform.GetChild(i);
        }
    }


}
