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

    public GameObject CheckForClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                return hit.transform.gameObject;
            }
        }

        return null;
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
