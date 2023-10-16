using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WayPointFollower : MonoBehaviour
{
    [SerializeField] private float speed = 1; 
    [SerializeField] private int nextWaypointIndex = 1; 
    [SerializeField] private float reachedWaypointClearance = 0.25f;
    [SerializeField] private Path path;

    void Awake()
    {// find an object with the type path so in this case it uses the path script very simple i know
        path = FindObjectOfType<Path>();
    }

    // Start is called before the first frame update
    void Start()
    { // make the enemy set to the first waypoint
        transform.position = path.waypoints[0].position;
       
    }

    // Update is called once per frame
    void Update()
    { //make the enemy move towrads the waypoints
        transform.position = Vector3.MoveTowards(transform.position, path.waypoints[nextWaypointIndex].position, Time.deltaTime * speed);

        //Check for the distance between the Enemy and the next waypoint is lesser than the newly created reachedWaypointClearance
        if (Vector3.Distance(transform.position, path.waypoints[nextWaypointIndex].position) <= reachedWaypointClearance)
        {
            nextWaypointIndex+= 1;
        }
        // is greater or equal then the amount of waypoints
        if (nextWaypointIndex >= path.waypoints.Length) 
        {
            nextWaypointIndex = 0;
        }
    }
}
