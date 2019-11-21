using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Node : MonoBehaviour {


public Color hovercolor;
    public Color notenoughmoney;

 

    public Vector3 offset;
    [HideInInspector]
        public GameObject turret;
    [HideInInspector]
    public Turretblueprint turretblueprint;
    [HideInInspector]
    public bool isUpgraded = false;
    
   
    private Renderer rend;
    
    private Color startcolor;
    Buildmanager buildmanager;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        startcolor = rend.material.color;

        buildmanager = Buildmanager.instance;
    }
    private void OnMouseDown()
    {
 
           
if (turret != null)
        {

            buildmanager.SelectNode(this);

            return;

        }

        if (!buildmanager.Canbuld)
        {
            FindObjectOfType<AudioManager>().Play("Lowmoney");
           
            return;
        }



        Buildturret(buildmanager.Geturrettobuild());

       
        FindObjectOfType<AudioManager>().Play("Buildturret");

        
        
    }

    void Buildturret(Turretblueprint blueprint)
        {

        if (PlayerStats.Money < blueprint.Cost)
        {
            return;
        }
        else if (PlayerStats.Money >= blueprint.Cost)
        {
            PlayerStats.Money -= blueprint.Cost;

        }



        GameObject _turret = (GameObject)Instantiate(blueprint.prefab, Getbuildposition, Quaternion.identity);
      turret = _turret;


        turretblueprint = blueprint;

        GameObject effect = (GameObject)Instantiate(buildmanager.buildeffect, Getbuildposition, Quaternion.identity);
        Destroy(effect, 1.5f);

    }

    public Vector3 Getbuildposition
    {
        get
        {
            return transform.position;
        }
    }

    public void Sellturet()
    {if(!isUpgraded)
        {
 PlayerStats.Money += turretblueprint.GetnonupgradedsellAmount();
        Destroy(turret);
        turretblueprint = null;
        }
    else
        {
            PlayerStats.Money += turretblueprint.GetUpgradesellamount();
            Destroy(turret);
            turretblueprint = null;
        }
       

    }

    private void OnMouseEnter()

    {
       

        FindObjectOfType<AudioManager>().Play("Overplacement");
 //     if (EventSystem.current.IsPointerOverGameObject())
 //       {
 //return;
 //       }
         

        if (!buildmanager.Canbuld)
        {
            return;
        }
       if(buildmanager.HasMoney)
        {
rend.material.color = hovercolor;
        }
       else if(!buildmanager.HasMoney)
        {
            rend.material.color = notenoughmoney;
        }
        

    }
    private void OnMouseExit()
    {
        if (!buildmanager.Canbuld)
        {
            return;
        }
        rend.material.color = startcolor;
    }
    public void Upgradeturret()
    {
        if (PlayerStats.Money < turretblueprint.upgradecost)
        {
            return;
        }
        else
        {
            PlayerStats.Money -= turretblueprint.upgradecost;
            Destroy(turret);
        }


        isUpgraded = true;


        GameObject _turret = (GameObject)Instantiate(turretblueprint.upgradedprefab, Getbuildposition, Quaternion.identity);
        turret = _turret;
        GameObject effect = (GameObject)Instantiate(buildmanager.buildeffect, Getbuildposition, Quaternion.identity);
        Destroy(effect, 5f);
    }
}
