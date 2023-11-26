using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointsFollower : MonoBehaviour
{


    public float speed = 3f;

    private Transform target;
    private int currentWaypointIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        InitializeWaypoints();
    }

    // Update is called once per frame
    void Update()
    {
        MoveTowardsWaypoint();
    }

    void InitializeWaypoints()
    {
        if (WayPoints.point.Length > 0)
        {
            SetTarget(WayPoints.point[0]);
        }
        else
        {
            Debug.LogError("No waypoints assigned!");
        }
    }

    void MoveTowardsWaypoint()
    {
        if (target == null)
        {
            return; // No target, nothing to do
        }

        Vector2 dir = target.position - transform.position;
        transform.Translate(speed * Time.deltaTime * dir.normalized);

        if (Vector2.Distance(transform.position, target.position) <= 0.2f)
        {
            HandleWaypointReached();
        }
    }

    void HandleWaypointReached()
    {
        // Object reached the current target waypoint
        currentWaypointIndex++;

        if (currentWaypointIndex < WayPoints.point.Length)
        {
            SetTarget(WayPoints.point[currentWaypointIndex]);
        }
        else
        {
            HandleAllWaypointsReached();
        }
    }

    void HandleAllWaypointsReached()
    {
        // All waypoints reached, you might want to reset or loop through waypoints
        Debug.Log("All waypoints reached!");
        SetTarget(null);
    }

    void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }
}

