using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //When called by DetectNode, checks if mouse is down, fires ray, and returns the position of the node hit.
    public Vector3 CheckForClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                return hit.transform.gameObject.transform.position;
            }
        }

        return new Vector3(0, 0, 0);
    }
    
    //Shows the waypoints, then checks for click. Compares clicked position with positions of adjacent nodes, returns clicked node if there's a match. Hides adjacent nodes.
    public GameObject DetectNode(GameObject currentNode)
    {
        /*
        foreach (var node in currentNode.GetComponent<Waypoint>().GetNeighbors()) //shows the adjacent waypoints
        {
            node.GetComponent<Renderer>().enabled = true;
        }
        */
        
        //Vector3 clickedPosition = CheckForClick(); //saves whatever was clicked
        
        Debug.Log("Created fake clicked position");
        Vector3 clickedPosition = new Vector3(0, 0, 0);
        
        Debug.Log("Checking for clicked position in neighbors");
        foreach (var node in currentNode.GetComponent<Waypoint>().GetNeighbors())
        {
            if (clickedPosition == node.transform.position)
            {
                Debug.Log("Node found");
                return node;
            }
        }
        
        /*
        foreach (var node in currentNode.GetComponent<Waypoint>().GetNeighbors()) //hides the adjacent waypoints
        {
            node.GetComponent<Renderer>().enabled = false;
        }
        */
        
        Debug.Log("No node found");
        return null;
    }
}
