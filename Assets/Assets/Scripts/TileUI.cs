using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TileUI : MonoBehaviour
{
    private Tile target;
    //TileUI
    public GameObject ui;
   
    //설치된 터렛의 업그레이드 비용
    public Text upgradeCost;

    public Button upgradeButton;

    public Button SellButton;

    public Text sellPrice;
    public TurretBluePrint turretBluePrint;

    public GameObject goldimpact;
    public void Settarget(Tile _target)
    {
        this.target = _target;
        this.transform.position = target.GetBuildPosition();

        if(!target.isUpgrade)
        {
            upgradeCost.text = _target.turretBlueprint.upgradeCost.ToString() + "G";
           
            upgradeButton.interactable = true;
            
        }
        else
        {
            upgradeCost.text = "완료";
            upgradeButton.interactable = false;
            
        }
        sellPrice.text = target.turretBlueprint.sellprice.ToString() + "G";
        ui.SetActive(true);
    }

    
    public void Hide()
    {
        ui.SetActive(false);
    }

    public void Upgrade()
    {
        target.UpgradeTurret();
        if (target.isUpgrade)
        {
            upgradeButton.interactable = false;
        }
    }

    public void Sell()
    {
        target.sellTurret();
       
        Hide();

        Instantiate(goldimpact, transform.position, transform.rotation);
        
    }

    

}
