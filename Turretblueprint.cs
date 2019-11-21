using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Turretblueprint  {

    public GameObject prefab;
    public int Cost;

    public GameObject upgradedprefab;

    public int upgradecost;

    public int GetnonupgradedsellAmount()
    {
        return Cost/2 ;


    }
    public int GetUpgradesellamount()
    {
        return upgradecost/2;
    }
}
