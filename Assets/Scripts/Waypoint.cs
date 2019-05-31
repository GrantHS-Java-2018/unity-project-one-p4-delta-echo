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
            neighbors.Add(/*Instantiate(*/neighbor/*, transform)*/);
        }

        RoomSet();
        Debug.Log("Neighbors instantiated");
    }

    private void RoomSet()
    {
        if (monsterPrefabs.Count == 1)
        {
            monsters.Add(Instantiate(monsterPrefabs[0], transform));
            treasure = Instantiate(treasurePrefab, transform);
        }
        else if (monsterPrefabs.Count == 3)
        {
            foreach (var monster in monsterPrefabs)
            {
                monsters.Add(Instantiate(monster, transform));
            }
        }
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
