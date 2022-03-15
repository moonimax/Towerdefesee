using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Serializable로 터렛 속성을 지정해준다.
[System.Serializable]

//상점에서 파는 품목의 속성 관리하는 직렬화 클래스
public class TurretBluePrint
{
   public GameObject BuildTurretPrefab; //터렛의 프리팹
   public int price;  // 터렛의 가격
   public int sellprice;
     


    public GameObject upgradePrefab;  //업그레이드 터렛의 프리팹
    public int upgradeCost;           //업그레이드 가격

    public Vector3 offsetPos;  //터렛 설치할때 위치 보정값
    

}







