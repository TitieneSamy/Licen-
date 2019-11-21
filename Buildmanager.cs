using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buildmanager : MonoBehaviour {

    public static Buildmanager instance;

    private void Awake()
    {

        instance = this;

    }

    public GameObject standardturretprefab;

    public GameObject MissleLauncherprefab;

    public GameObject LaserCannon;

    public GameObject buildeffect;

    private Turretblueprint turrettobuild;
    private Node selectedNode;

    public Nodeui nodeui;

    public bool Canbuld
    {
        get { return turrettobuild != null; }
    }
    public bool HasMoney
    {
        get { return PlayerStats.Money >=turrettobuild.Cost; }
    }

    public void Selectturrettobuild(Turretblueprint turret)
    {
        turrettobuild = turret;
    }

  
    public void SelectNode(Node node)
    {
        if(selectedNode==node)
        {
            DeselectNode();
            return;
        }

        selectedNode = node;
        turrettobuild = null;

        nodeui.SetTarget(node);
    }

    public void DeselectNode()
    {
        selectedNode = null;
        nodeui.Hide();
    }

    public void SelectTurrettobuild(Turretblueprint turret)
    {
        turrettobuild = turret;
        DeselectNode();
        return;

        

    }
    public Turretblueprint Geturrettobuild()
    {
        return turrettobuild;
    }
}

