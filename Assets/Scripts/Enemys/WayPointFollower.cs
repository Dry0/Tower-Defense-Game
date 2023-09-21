using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WayPointFollower : MonoBehaviour
{
    [SerializeField] public Transform[] waypoints;
    [SerializeField] private float speed = 1;
    [SerializeField] private int nextWaypointIndex = 1;
    [SerializeField] private float reachedWaypointClearance = 0.25f;
    [SerializeField] private Path path;

    // Start is called before the first frame update
    void Start()
    { // make the enemy set to the first waypoint
        transform.position = waypoints[0].position;
    }

    // Update is called once per frame
    void Update()
    { //make the enemy move towrads the waypoints
        transform.position = Vector3.MoveTowards(transform.position, waypoints[nextWaypointIndex].position, Time.deltaTime * speed);
        //Check for the distance between the Enemy and the next waypoint is lesser than the newly created reachedWaypointClearance
        if (Vector3.Distance(transform.position, waypoints[nextWaypointIndex].position) <= reachedWaypointClearance)
        {
            nextWaypointIndex+= 1;
        }
        // is greater or equal then the amount of waypoints
        if (nextWaypointIndex >= waypoints.Length) 
        {
            nextWaypointIndex = 0;
        }
    }

    public class FindAnyObjectByType : MonoBehaviour
    {
        private FindAnyObjectByType target;

        private void Awake()
        {
            //path = FindObjectOfType<Path>();
        }
    }
}
