using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{

    BuildManager buildManager;

    //기본 터렛과 미사일 런처를 선언
    public TurretBluePrint standardTurret;
    public TurretBluePrint missileTurret;
    public TurretBluePrint laserTurret;
    

    //GameObject prefeb;
     void Start()
    {
        //turret1.price = 100;
        //turret1.BuildTurretPrefab = prefeb;
        buildManager = BuildManager.instance;  
    }

    public void PurchaseStandardTurret()
    {
       
        //buildManager.SetTurretToBuild(buildManager.standardTurretPrefab);
       
        buildManager.SetTurretToBuild(standardTurret);
    
    }


    public void PurchaseMissileTurret()
    {
        
        //buildManager.SetTurretToBuild(buildManager.missileTurretPrefab);
        //BluepPrint의 미사일터렛의 인스턴스 생성
       
        buildManager.SetTurretToBuild(missileTurret);
    }

    public void PurchaseLaserTurret()
    {
        Debug.Log("레이저 터렛을 구매하였습니다.");
        buildManager.SetTurretToBuild(laserTurret);
    }

   

}
