using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;
    //public GameObject standardTurretPrefab;
    // public GameObject missileTurretPrefab;

    //�����ϱ� ���� �ͷ��� ���� ������, ������ ��� �ִ� ����      
    public TurretBluePrint turretToBuild;

    //�����ϱ� ���� �÷��̾ ���� ������, ������ ��� �ִ� ����


    // �ͷ� ��ġ ȿ�� ������ ��������
    public GameObject ImpactTurrets;

    //�ܵ� ���� ������
    public int result;

    public Text MyMoney;
    public Text LifeShow;

 


    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogError("�ϳ����� �� ����");
            return;
        }
        instance = this;
    }

    public TurretBluePrint GetTurretToBuild()
    {
        return turretToBuild;
    }

   

    public void SetTurretToBuild(TurretBluePrint turret)
    {
        turretToBuild = turret;
        DeselectNode();
    }

    public void SetMoney(int result)
    {
        PlayerStats.money = result;
    }
    public bool CanBuild
    {
        get { return turretToBuild != null; }
    }

    public bool HasMoney
    {
        get { return PlayerStats.money >= turretToBuild.price; }
    }
    
    /*public void TurretBuildOn(Tile tile)
    {
        if (PlayerStats.money < turretToBuild.price)
        {
            Debug.Log("���� �����մϴ�.");
            return;
        }
            //���� ���� ���ǰ� �׻� �ڵ��� �Ұ�!
            PlayerStats.money -= turretToBuild.price;
            //�ͷ��� ��ġ�Ѵ�
            GameObject _turret = (GameObject)Instantiate(turretToBuild.BuildTurretPrefab, tile.transform.position, transform.rotation);
            tile.turret = _turret;
            if(_turret != null)
            {
                 Instantiate(ImpactTurrets, tile.transform.position + tile.positionOffset, transform.rotation);
            }
           // turretToBuild = null;
           

        
      
        Debug.Log($"���� ���� :{PlayerStats.money}�̴�.");
    }
    */
    
    

    
    private void Update()
    {
        
        MyMoney.text = PlayerStats.money.ToString() + "G";
        /*
         int moony = PlayerStats.money;
        MyMoney.text = mooney.ToString();
        */

        LifeShow.text = PlayerStats.Life.ToString();
    }

    //������ Ÿ�� ����
    private Tile selectTile;

    //Tile UI ������Ʈ
    public TileUI tileUI;

    public void SelectTile(Tile tile)
    {
        if(selectTile == tile)
        {
            DeselectNode();
            return;
        }

        selectTile = tile;
        turretToBuild = null;

        tileUI.Settarget(tile);
        
    }
    public void DeselectNode()
    {
        selectTile = null;
        tileUI.Hide();
    }
}
   


