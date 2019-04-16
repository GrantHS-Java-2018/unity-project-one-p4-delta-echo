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

        while (openList.Count > 0)
        {
            //Examines start node, adds neighbors, picks node most likely to be on right path based on distance
            currentNode = openList.Values[0];
            openList.RemoveAt(0);
            var distance = currentNode.Distance;
            closedList.Add(currentNode);
            if (currentNode == endNode)
            {
                break;
            }

            foreach (var neighbor in currentNode.neighbors)
            {
                if (closedList.Contains(neighbor) || openList.ContainsValue( neighbor))
                {
                    continue;
                }

                neighbor.Previous = currentNode;
                neighbor.Distance = distance + (neighbor.transform.position - currentNode.transform.position).magnitude;
                var distanceToTarget = (neighbor.transform.position - endNode.transform.position).magnitude;
                openList.Add(neighbor.Distance + distanceToTarget, neighbor);
            }
        }

        if (currentNode == endNode)
        {
            while (currentNode.Previous != null)
            {
                currentPath.Push(currentNode.transform.position);
                currentNode = currentNode.Previous;
            }
            currentPath.Push(transform.position);
        }
    }

    public void Stop()
    {
        currentPath = null;
        moveTimeTotal = 0;
        moveTimeCurrent = 0;
    }

    //This update function is for patrolling things that update every frame. We don't strictly need it, but I'm including it so we can reference it and use it to control our movement.
    void Update()
    {
        if (currentPath != null && currentPath.Count > 0)
        {
            if (moveTimeCurrent < moveTimeTotal)
            {
                moveTimeCurrent += Time.deltaTime;
                if (moveTimeCurrent > moveTimeTotal)
                {
                    moveTimeCurrent = moveTimeTotal;
                }

                transform.position = Vector3.Lerp(currentWaypointPosition, currentPath.Peek(),
                    moveTimeCurrent / moveTimeTotal);
            }
            else
            {
                currentWaypointPosition = currentPath.Pop();
                if (currentPath.Count == 0)
                {
                    Stop();
                }
                else
                {
                    moveTimeCurrent = 0;
                    moveTimeTotal = (currentWaypointPosition - currentPath.Peek()).magnitude / walkSpeed;
                }
            }
        }
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
