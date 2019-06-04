using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public List<GameObject> neighborPrefabs = new List<GameObject>();
    public List<GameObject> monsterPrefabs = new List<GameObject>();
    public GameObject treasurePrefab;
    
    private List<GameObject> neighbors = new List<GameObject>();
    private List<GameObject> monsters = new List<GameObject>();
    private GameObject treasure;

    private void Start()
    {
        Debug.Log("Waypoint initialized");
        Debug.Log("Instantiating neighbors:");
        foreach (var neighbor in neighborPrefabs)
        {
            neighbors.Add(neighbor);
        }

        RoomSet();
        Debug.Log("Neighbors instantiated");
    }

    private void RoomSet()
    {
        if (monsterPrefabs.Count == 0 || monsterPrefabs[0] == null)
        {
            Debug.Log("Empty room, chamber, or hallway");
        }
        else 
        {
            Debug.Log("Room or chamber");
            foreach (var monster in monsterPrefabs)
            {
                monsters.Add(Instantiate(monster, transform));
            }

            if (monsterPrefabs.Count == 1)
            {
                Debug.Log("It's a room, instantiating treasure");
                treasure = Instantiate(treasurePrefab, this.transform);
            }
        }
        Debug.Log("Instantiated monsters");
    }

    public Waypoint Previous
    {
        get;
        set;
    }

    public float Distance
    {
        get;
        set;
    }

    public List<GameObject> GetNeighbors()
    {
        return neighbors;
    }

    //Draws lines on map, only in edit mode
    /*private void OnDrawGizmos()
    {
        if (neighborPrefabs == null)
        {
            return;
        }

        Gizmos.color = new Color(0f, 0f, 0f);
        foreach (var neighbor in neighborPrefabs)
        {
            Gizmos.DrawLine(transform.position, neighbor.transform.position);
        }
    }
*/

    public GameObject GetTreasure()
    {
        return treasure;
    }

}
