using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]  //since we're not inherit anything from monobehavipour this line of code will make this stuff visible from inspector
public class TurretBluePrint 
{
    public GameObject prefab;

    public int cost;

    public GameObject upgradedPrefab;

    public int upgradeCost;

 public int GetSellAmount()
    {
        return cost/2;
    }

}
