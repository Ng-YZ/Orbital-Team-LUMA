using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{

    [SerializeField] private GameObject[] waypoints;
    private int currentWaypointIndex = 0; //index of first waypoint


    [SerializeField] private float speed = 2f;


    //sets position of moving platform each frame
    private void Update()
    {

        //first vector is the position of the currently active waypoint
        //second vector is the position of the moving platform
        //the <0.1f is because if the distance is less than 0, we want to switch to the next waypoint
        //but putting `< 0f` would be buggy, so we do 0.1f
        if (Vector2.Distance(waypoints[currentWaypointIndex].transform.position, transform.position) < 0.1f) 
        {
            currentWaypointIndex += 1;

            if (currentWaypointIndex >= waypoints.Length)
            {
                currentWaypointIndex = 0;
            }

        }

        //speed defines how many game units we want to move our platform (one unit = one tilemap square)
        //deltaTime is the interval of seconds between each frame, so we can move 2 units per second, independent of the framerate
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, Time.deltaTime*speed);


        
        
    }
}
