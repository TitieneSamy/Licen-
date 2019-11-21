using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Nodeui : MonoBehaviour {

    public GameObject ui;

    public Text Upgradecost;
    public Text Sellcost;
    private Node target;
    public Button upgradebuttn;

    public void SetTarget(Node _target)
    {
        target = _target;

        transform.position = target.Getbuildposition;
        if(!target.isUpgraded)
        {
 Upgradecost.text =  target.turretblueprint.upgradecost.ToString()+"$";
            upgradebuttn.interactable = true;
        }
        Sellcost.text = target.turretblueprint.GetnonupgradedsellAmount().ToString() + "$";



        if (target.isUpgraded)
        {
            Upgradecost.text = "Inbunatatit";
            upgradebuttn.interactable = false;
        }

        ui.SetActive(true);
    }
    public void Hide()
    {
        ui.SetActive(false);
    }
    public void Upgrade()
    {
        target.Upgradeturret();
        Buildmanager.instance.DeselectNode();
    }
    public void Sell()
    { target.Sellturet();
        Buildmanager.instance.DeselectNode();
       
        
    }
}
