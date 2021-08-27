using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class AIPathNavigator : MonoBehaviour
{
    public Transform targetPosition;

    private Seeker seeker;
    private CharacterController controller;

    public Path path;

    public float speed;

    public float nextWaypointDistance;

    private int currentWaypoint = 0;

    public bool reachedEndOfPath;

    public void Start()
    {
        seeker = GetComponent<Seeker>();
        seeker.pathCallback += OnPathComplete;
        controller = GetComponent<CharacterController>();
    }

    public void OnPathComplete(Path p)
    {
        Debug.Log("A path was calculated. Did it fail with an error? " + p.error);

        if (!p.error)
        {
            path = p;
            // Reset the waypoint counter so that we start to move towards the first point in the path
            currentWaypoint = 0;
            Debug.Log("Waypoints: " + seeker.GetCurrentPath().vectorPath.Count + " Current Waypoint: " + currentWaypoint);
        }
    }

    public void Update()
    {
        path = seeker.GetCurrentPath(); //Retrieve any path created by state of the AI

        if (path == null)
        {
            // We have no path to follow yet, so don't do anything
            return;
        }

        Debug.Log("We have a path");

        reachedEndOfPath = false;
        float distanceToWaypoint = Vector3.Distance(transform.position, path.vectorPath[currentWaypoint]);
        if(distanceToWaypoint < nextWaypointDistance)
        {
            if(currentWaypoint + 1 < path.vectorPath.Count)
            {
                currentWaypoint++;
                Debug.Log("Current Waypoint: " + currentWaypoint.ToString());
            }
            else
            {
                reachedEndOfPath = true;
            }
        }

        if(!reachedEndOfPath)
        {
            var speedFactor = Mathf.Sqrt(distanceToWaypoint / nextWaypointDistance);
            Vector3 dir = ((path.vectorPath[currentWaypoint] - transform.position) * -1).normalized;
            Vector3 velocity = dir * speed * speedFactor;
            Debug.Log("Velocity: " + velocity.ToString());
            controller.SimpleMove(velocity);
        }
        
    }
}
