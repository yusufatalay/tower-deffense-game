﻿using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("more than 1 build manager in sceene !!");
            return;
        }
        instance = this;
    }


    
    public GameObject buildEffect;

    public GameObject sellEffect;

    private TurretBluePrint turretToBuild;

    private Node selectedNode;

    public NodeUI nodeUI;

   public bool CanBuild { get { return turretToBuild != null; } }
   public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.cost; } }
 


    public void SelectNode(Node node)
    {

        if (selectedNode == node)
        {
            DeselectNode();
            return;
        }

        selectedNode = node;
        turretToBuild = null;

        nodeUI.SetTarget(node);

    }
    public void DeselectNode()
    {
        selectedNode = null;
        nodeUI.Hide();
    }


    public void SelectTurretToBuild(TurretBluePrint turret)
    {
        turretToBuild = turret;
        DeselectNode();
    }

    public TurretBluePrint GetTurretToBuild()
    {
        return turretToBuild;
    }
}
