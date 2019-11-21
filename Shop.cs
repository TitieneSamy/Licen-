using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    Buildmanager buildmanager;
    public Turretblueprint standardturret;
    public Turretblueprint misslelauncher;
    public Turretblueprint Lasercannon;
    private void Start()
    {
        buildmanager = Buildmanager.instance;
    }
    public void SelectStandardturret()
    {
        buildmanager.Selectturrettobuild(standardturret);
    }
    public void SelectMissleturret()
    {
        buildmanager.Selectturrettobuild(misslelauncher);


    }
    public void Selectlaser()
    {
        buildmanager.Selectturrettobuild(Lasercannon);
    }
}