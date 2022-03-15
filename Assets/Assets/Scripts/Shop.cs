using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{

    BuildManager buildManager;

    //�⺻ �ͷ��� �̻��� ��ó�� ����
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
        //BluepPrint�� �̻����ͷ��� �ν��Ͻ� ����
       
        buildManager.SetTurretToBuild(missileTurret);
    }

    public void PurchaseLaserTurret()
    {
        Debug.Log("������ �ͷ��� �����Ͽ����ϴ�.");
        buildManager.SetTurretToBuild(laserTurret);
    }

   

}
