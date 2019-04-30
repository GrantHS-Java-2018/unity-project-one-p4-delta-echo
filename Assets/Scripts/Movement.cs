﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Waypoint DetectNode(Waypoint currentNode)
    {
        foreach (var node in currentNode.GetComponent<Waypoint>().getNeighbors()) //shows the adjacent waypoints
        {
            node.GetComponent<Renderer>().enabled = true;
        }
        Waypoint clickedNode = null; //saves whatever was clicked
        foreach (var node in currentNode.GetComponent<Waypoint>().getNeighbors())
        {
            if (clickedNode.transform.position == node.transform.position)
            {
                return clickedNode;
            }
        }
        foreach (var node in currentNode.GetComponent<Waypoint>().getNeighbors()) //hides the adjacent waypoints
        {
            node.GetComponent<Renderer>().enabled = false;
        }
        return null;
    }
}
