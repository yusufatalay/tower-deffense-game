using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBluePrint standartTurret;
    public TurretBluePrint missileLauncher;
    public TurretBluePrint laserBeamer;

    BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance; 
    }


    public void SelectStandartTurret()
    {
        Debug.Log("Standart turret selected!");
        buildManager.SelectTurretToBuild(standartTurret);
    }
    public void SelectMissileLauncher()
    {
        Debug.Log("Missile launcher selected!");
        buildManager.SelectTurretToBuild(missileLauncher);
    }

    public void SelectLaserBeamer()
    {
        Debug.Log("Laser Beamer selected!");
        buildManager.SelectTurretToBuild(laserBeamer);
    }
}
