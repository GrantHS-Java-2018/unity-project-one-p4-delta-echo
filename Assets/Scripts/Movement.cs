using System.Collections;
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

    //When called by DetectNde, checks if mouse is down, fires ray, and returns the position of the node hit.
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
        foreach (var node in currentNode.GetComponent<Waypoint>().getNeighbors()) //shows the adjacent waypoints
        {
            node.GetComponent<Renderer>().enabled = true;
        }
        
        Vector3 clickedPosition = CheckForClick(); //saves whatever was clicked
        
        foreach (var node in currentNode.GetComponent<Waypoint>().getNeighbors())
        {
            if (clickedPosition == node.transform.position)
            {
                return node;
            }
        }
        
        foreach (var node in currentNode.GetComponent<Waypoint>().getNeighbors()) //hides the adjacent waypoints
        {
            node.GetComponent<Renderer>().enabled = false;
        }
        return null;
    }
    
}
