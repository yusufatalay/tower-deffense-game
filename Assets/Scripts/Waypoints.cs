using UnityEngine;

public class Waypoints : MonoBehaviour
{
    public static Transform[] points; //i made it static so i won't need a reference to this script (it is accessible from anywhere)  this array will hold the waypoints

    void Awake() //this function is called before the game starts adn after all the objects are initialized
    {
        points = new Transform[transform.childCount];   //i initialize the points array which declared above and the lenght of it is number of waypoints i have 
        for (int i = 0; i < points.Length; i++)
        {
             points[i] = transform.GetChild(i);   //i think its pretty obvious that i assign every child (waypoint) to the array i created above
        }
    }

}
