using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;
    //public GameObject standardTurretPrefab;
    // public GameObject missileTurretPrefab;

    //빌드하기 위한 터렛에 관한 프리팹, 가격을 담고 있는 변수      
    public TurretBluePrint turretToBuild;

    //빌드하기 위한 플레이어에 관한 프리팹, 가격을 담고 있는 변수


    // 터렛 설치 효과 프리팹 가져오기
    public GameObject ImpactTurrets;

    //잔돈 값을 저장함
    public int result;

    public Text MyMoney;
    public Text LifeShow;

 


    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogError("하나보다 더 생김");
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
            Debug.Log("돈이 부족합니다.");
            return;
        }
            //돈이 먼저 계산되게 항상 코딩을 할것!
            PlayerStats.money -= turretToBuild.price;
            //터렛을 설치한다
            GameObject _turret = (GameObject)Instantiate(turretToBuild.BuildTurretPrefab, tile.transform.position, transform.rotation);
            tile.turret = _turret;
            if(_turret != null)
            {
                 Instantiate(ImpactTurrets, tile.transform.position + tile.positionOffset, transform.rotation);
            }
           // turretToBuild = null;
           

        
      
        Debug.Log($"남은 돈은 :{PlayerStats.money}이다.");
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

    //선택한 타일 저장
    private Tile selectTile;

    //Tile UI 오브젝트
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
   


