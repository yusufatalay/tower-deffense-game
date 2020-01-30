using UnityEngine;
using UnityEngine.EventSystems;
public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Color notEnoughMoneyColor; 
    private Color startColor;
    
    public Vector3 offSet = new Vector3(0f, 0.5f, 0f);
   
    [HideInInspector]
    public GameObject turret;
    [HideInInspector]
    public TurretBluePrint turretBlueprint;
    [HideInInspector]
    public bool isUpgraded = false; 
    
    private Renderer rend;

       
    BuildManager buildManager;

    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        buildManager = BuildManager.instance;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + offSet;
    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        

        if (turret != null)
        {
            buildManager.SelectNode(this);
            return;
        }

        if (!buildManager.CanBuild)
        {
            return;
        }
        BuildTurret(buildManager.GetTurretToBuild());


    }

    void BuildTurret(TurretBluePrint blueprint)
    {
        if (PlayerStats.Money < blueprint.cost)
        {
            Debug.Log("Not enough money ");
            return;
        }

        PlayerStats.Money -= blueprint.cost;
        GameObject _turret = (GameObject)Instantiate(blueprint.prefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;
        turretBlueprint = blueprint;

        GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity); //quaternion.identity  is for when you don't want to rotate that 
        Destroy(effect, 5f);
        Debug.Log("turret build! ");
    }

    public void UpgradeTurret()
    {
        if (PlayerStats.Money < turretBlueprint.upgradeCost)
        {
            Debug.Log("Not enough money to upgrade ");
            return;
        }

        PlayerStats.Money -= turretBlueprint.upgradeCost;

        

        Destroy(turret); //getting rid of the old turret
        //building new one  

        GameObject _turret = (GameObject)Instantiate(turretBlueprint.upgradedPrefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;

        GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity); //quaternion.identity  is for when you don't want to rotate that 
        Destroy(effect, 5f);
        isUpgraded = true;
        Debug.Log("turret upgraded! ");
    }

    public void SellTurret()
    {
        PlayerStats.Money += turretBlueprint.GetSellAmount();
        
        GameObject effect = (GameObject)Instantiate(buildManager.sellEffect, GetBuildPosition(), Quaternion.identity); //quaternion.identity  is for when you don't want to rotate that 
        Destroy(effect, 5f);

        Destroy(turret);
        turretBlueprint = null;

    }


    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (!buildManager.CanBuild)
        {
            return;
        }
        if (buildManager.HasMoney)
        {
            rend.material.color = hoverColor;
        }
        else
        {
            rend.material.color = notEnoughMoneyColor;
        }

        
    }
    void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
