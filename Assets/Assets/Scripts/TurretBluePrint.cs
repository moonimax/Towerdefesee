using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Serializable�� �ͷ� �Ӽ��� �������ش�.
[System.Serializable]

//�������� �Ĵ� ǰ���� �Ӽ� �����ϴ� ����ȭ Ŭ����
public class TurretBluePrint
{
   public GameObject BuildTurretPrefab; //�ͷ��� ������
   public int price;  // �ͷ��� ����
   public int sellprice;
     


    public GameObject upgradePrefab;  //���׷��̵� �ͷ��� ������
    public int upgradeCost;           //���׷��̵� ����

    public Vector3 offsetPos;  //�ͷ� ��ġ�Ҷ� ��ġ ������
    

}







