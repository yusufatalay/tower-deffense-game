using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int Money;  //static variables carried on from one scene to another thats why i assign this to non static variable at the start method
    public int startMoney=4000;
    public static int Lives;
    public int startLives = 20;
    public static int Rounds;
    void Start()
    {
        Rounds = 0;
        Money = startMoney;
        Lives = startLives;
    }
}
