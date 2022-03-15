 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class Tile : MonoBehaviour
{
    [HideInInspector]
    public GameObject turret;
    public Color hoverColor;
    private Renderer rend;
    private Color startcolor;

    public GameObject basicTurretPrefab;

    public Vector3 positionOffset;

    //PlayerStat don = new PlayerStat();

    TurretBluePrint price = new TurretBluePrint();

    //터렛을 새로 생성하는 변수 선언

    //public bool CanBuild

    public BuildManager buildManager;

    //해당 타일을 젖아할때 값을 가지고 있어야함
    [HideInInspector]
    public TurretBluePrint turretBlueprint;
    //터렛의 업그레이드 여부 체크
    [HideInInspector]
    public bool isUpgrade = false;
    public bool isSell = false;

    TileUI tileUI;
    void Start()
    {
        rend = GetComponent<Renderer>();
        startcolor = rend.material.color;
        // Renderer 객체 불러와서 초기화
        // rend = gameObject.GetComponent<Renderer>();
        //타일의 초기 색 가져오기
        // startcolor = rend.material.color;
        //타일의 초기 메터리얼 가져오기
        buildManager = BuildManager.instance;
    }

    void Update()
    {

    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }

    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (buildManager.GetTurretToBuild() == null)
        {
            return;
        }

        //가진돈보다 터렛의 가격이 더 비싸면 빨간색으로 타일 색을 표시한다.
        if (PlayerStats.money < buildManager.GetTurretToBuild().price)
        {
            rend.material.color = Color.red;
        }
        //Debug.Log("오브젝트 위에 마우스가 올라가있습니다.");
        //GetComponent<MeshRenderer>().material.color = hoverColor;
        else
        {
            rend.material.color = hoverColor;
        }
    }



    //마우스가  object에 머물다가 빠져나왔을때
    private void OnMouseExit()
    {

        // GetComponent<MeshRenderer>().material.color = Color.white;
        //rend = gameObject.GetComponent<MeshRenderer>();
        rend.material.color = startcolor;
        
    }


    // 마우스로 오븍젝트를 클릭하고 뗏을때
    private void OnMouseUp()
    {  //타일위에 버튼(UI)이 있을 경우
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (buildManager.GetTurretToBuild() == null)
        {
            return;
        }
        //기본 터렛을 설치한다
        
    }

    //마우스로 오브젝트를 클릭할때
    private void OnMouseDown()
    {   //타일위에 버튼 (UI)가 있는 경우
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        //저장된 터렛이 있는 경우
        if (buildManager.GetTurretToBuild() == null)
        {
            return;
        }

        //타일위에 터렛이 설치되었는지 검사
        if (turret != null)
        {
            buildManager.SelectTile(this);
            Debug.Log("타일위에 터렛이 있다");
            return;
        }


        //현재 가지고 있는 돈이 터렛의 가격보다 적으면
        //if -> PlayerStats.money < turret1.price = return;
        //if(


        //GameObject turretToBuild = buildManager.GetTurretToBuild().BuildTurretPrefab;


        TurretBuildOn(buildManager.turretToBuild);




        //가진돈 차감(터렛 가격만큼)

        //PlayerStats.money -= turret1.price (400 - 100) money = 300(-100)


    }

    
    private void TurretBuildOn(TurretBluePrint blueprint)
    {

        if (PlayerStats.money < buildManager.GetTurretToBuild().price)
        {
            Debug.Log("돈이 부족합니다.");
            return;
        }
        //돈이 먼저 계산되게 항상 코딩을 할것!
        PlayerStats.money -= blueprint.price;
        //터렛을 설치한다
        GameObject _turret = (GameObject)Instantiate(blueprint.BuildTurretPrefab, transform.position, transform.rotation);
        turret = _turret;
        if (_turret != null)
        {
            Instantiate(buildManager.ImpactTurrets, transform.position + positionOffset, transform.rotation);
        }
        // turretToBuild = null;
        
        turretBlueprint = blueprint;
    }
    
    public void UpgradeTurret()
    {
        if (PlayerStats.money < turretBlueprint.upgradeCost)
        {
            Debug.Log("업그레이드 할 돈이 부족합니다.");
            return;
        }

        Destroy(turret);
        PlayerStats.money -= turretBlueprint.upgradeCost;
        //업그레이드 터렛을 설치
        GameObject _turret = (GameObject)Instantiate(turretBlueprint.upgradePrefab, transform.position, transform.rotation);
        turret = _turret;

        // 업그레이드 체크 확인
        isUpgrade = true;

        if (_turret != null)
        {
            Instantiate(buildManager.ImpactTurrets, transform.position + positionOffset, transform.rotation);
        }


    }


    public void sellTurret()
    {
         //PlayerStats.money 
        Destroy(turret);

        //업그레이드 체크 초기화
        isUpgrade = false;

        PlayerStats.money += turretBlueprint.price / 2;
    }

}

   


