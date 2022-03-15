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

    //�ͷ��� ���� �����ϴ� ���� ����

    //public bool CanBuild

    public BuildManager buildManager;

    //�ش� Ÿ���� �����Ҷ� ���� ������ �־����
    [HideInInspector]
    public TurretBluePrint turretBlueprint;
    //�ͷ��� ���׷��̵� ���� üũ
    [HideInInspector]
    public bool isUpgrade = false;
    public bool isSell = false;

    TileUI tileUI;
    void Start()
    {
        rend = GetComponent<Renderer>();
        startcolor = rend.material.color;
        // Renderer ��ü �ҷ��ͼ� �ʱ�ȭ
        // rend = gameObject.GetComponent<Renderer>();
        //Ÿ���� �ʱ� �� ��������
        // startcolor = rend.material.color;
        //Ÿ���� �ʱ� ���͸��� ��������
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

        //���������� �ͷ��� ������ �� ��θ� ���������� Ÿ�� ���� ǥ���Ѵ�.
        if (PlayerStats.money < buildManager.GetTurretToBuild().price)
        {
            rend.material.color = Color.red;
        }
        //Debug.Log("������Ʈ ���� ���콺�� �ö��ֽ��ϴ�.");
        //GetComponent<MeshRenderer>().material.color = hoverColor;
        else
        {
            rend.material.color = hoverColor;
        }
    }



    //���콺��  object�� �ӹ��ٰ� ������������
    private void OnMouseExit()
    {

        // GetComponent<MeshRenderer>().material.color = Color.white;
        //rend = gameObject.GetComponent<MeshRenderer>();
        rend.material.color = startcolor;
        
    }


    // ���콺�� ������Ʈ�� Ŭ���ϰ� ������
    private void OnMouseUp()
    {  //Ÿ������ ��ư(UI)�� ���� ���
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (buildManager.GetTurretToBuild() == null)
        {
            return;
        }
        //�⺻ �ͷ��� ��ġ�Ѵ�
        
    }

    //���콺�� ������Ʈ�� Ŭ���Ҷ�
    private void OnMouseDown()
    {   //Ÿ������ ��ư (UI)�� �ִ� ���
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        //����� �ͷ��� �ִ� ���
        if (buildManager.GetTurretToBuild() == null)
        {
            return;
        }

        //Ÿ������ �ͷ��� ��ġ�Ǿ����� �˻�
        if (turret != null)
        {
            buildManager.SelectTile(this);
            Debug.Log("Ÿ������ �ͷ��� �ִ�");
            return;
        }


        //���� ������ �ִ� ���� �ͷ��� ���ݺ��� ������
        //if -> PlayerStats.money < turret1.price = return;
        //if(


        //GameObject turretToBuild = buildManager.GetTurretToBuild().BuildTurretPrefab;


        TurretBuildOn(buildManager.turretToBuild);




        //������ ����(�ͷ� ���ݸ�ŭ)

        //PlayerStats.money -= turret1.price (400 - 100) money = 300(-100)


    }

    
    private void TurretBuildOn(TurretBluePrint blueprint)
    {

        if (PlayerStats.money < buildManager.GetTurretToBuild().price)
        {
            Debug.Log("���� �����մϴ�.");
            return;
        }
        //���� ���� ���ǰ� �׻� �ڵ��� �Ұ�!
        PlayerStats.money -= blueprint.price;
        //�ͷ��� ��ġ�Ѵ�
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
            Debug.Log("���׷��̵� �� ���� �����մϴ�.");
            return;
        }

        Destroy(turret);
        PlayerStats.money -= turretBlueprint.upgradeCost;
        //���׷��̵� �ͷ��� ��ġ
        GameObject _turret = (GameObject)Instantiate(turretBlueprint.upgradePrefab, transform.position, transform.rotation);
        turret = _turret;

        // ���׷��̵� üũ Ȯ��
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

        //���׷��̵� üũ �ʱ�ȭ
        isUpgrade = false;

        PlayerStats.money += turretBlueprint.price / 2;
    }

}

   


