using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]   //its not inherited from monobehaviours but i want it to be visible in the inspector
                        //this class script is similar to the "turretBlueprint" class
public class Wave 
{
    public GameObject enemy;
    public int count;
    public float rate;
}
