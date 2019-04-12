using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class PathManager : MonoBehaviour
{
    public float walkSpeed = 5.0f;

    private Stack<Vector3> currentPath;
    private Vector3 currentWaypointPosition;
    private float moveTimeTotal;
    private float moveTimeCurrent;

    public void NavigateTo(Vector3 destination)
    {
        //Detect closest node to start and closest to end
        currentPath = new Stack<Vector3>();
        var currentNode = FindClosestWaypoint(transform.position);
        var endNode = FindClosestWaypoint(destination);
        if (currentNode == null || endNode == null || currentNode == endNode)
        {
            return;
        }

        //closedList keeps track of visited nodes to prevent system from going into an infinite loop and trying the same paths repeatedly.
        var openList = new SortedList<float, Waypoint>();
        var closedList = new List<Waypoint>();
        openList.Add(0, currentNode);
        currentNode.Previous = null;
        currentNode.Distance = 0f;
        
        
    }

    public void Stop()
    {
        //stuff
    }

    void Update()
    {
        //stuff
    }

    //searches for closest waypoint, if nearest is less than the last closest, set it as the new closest, return result.
    private Waypoint FindClosestWaypoint(Vector3 target)
    {
        GameObject closestWaypoint = null;
        float closestDistance = Mathf.Infinity;
        foreach (var waypoint in GameObject.FindGameObjectsWithTag("Waypoint"))
        {
            var distance = (waypoint.transform.position - target).magnitude;
            if (distance < closestDistance)
            {
                closestWaypoint = waypoint;
                closestDistance = distance;
            }
        }

        if (closestWaypoint != null)
        {
            return closestWaypoint.GetComponent<Waypoint>();
        }

        return null;
    }
    
}
