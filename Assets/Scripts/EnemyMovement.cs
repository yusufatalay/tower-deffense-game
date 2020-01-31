using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour
{
    
    private Transform target;   //transforms of enemies targets in this case thay are the waypoints that i created
    private int wavepointIndex = 0; //this will be the current way point index the enemy will be pursuing
    private Enemy enemy;
    private void Start()
    {
        enemy = GetComponent<Enemy>();

        target = Waypoints.points[0];  //at the start i want't enemy to got to the first waypoint

    }
    void Update()
    {
        Vector3 dir = target.position - transform.position;  //i created a vector towards to the current waypoint from the enemy
        transform.Translate(dir.normalized * enemy.speed * Time.deltaTime, Space.World);//normalized makes the vector's magnitude '1'
        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWayPoint();
        }
        enemy.speed = enemy.startSpeed;

    }

        void GetNextWayPoint()
        {
            if (wavepointIndex >= Waypoints.points.Length - 1)  //when enemy reaches the end it will be destroyed
            {
                EndPath();
                return;
            }
            wavepointIndex++;
            target = Waypoints.points[wavepointIndex];
       // transform.LookAt(target.position);   make the enemy to look at the next waypoint enable it when schreckifying
        }
        
    

    void EndPath()
    {
        PlayerStats.Lives--;
        WaveSpawner.EnemiesAlive--;
        Destroy(gameObject);
    }
}
