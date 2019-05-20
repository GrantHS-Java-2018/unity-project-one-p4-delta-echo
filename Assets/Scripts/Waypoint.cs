using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public List<GameObject> neighborPrefabs;
    public GameObject monsterPrefab;
    public GameObject treasurePrefab;
    
    private List<GameObject> neighbors = new List<GameObject>();
    private GameObject monster;
    private GameObject treasure;

    private void Start()
    {
        foreach (var neighbor in neighborPrefabs)
        {
            neighbors.Add(Instantiate(neighbor, this.transform));
        }

        monster = Instantiate(monsterPrefab, this.transform);
        treasure = Instantiate(treasurePrefab, this.transform);
    }

    public List<GameObject> GetNeighbors()
    {
        return neighbors;
    }

    //Draws lines on map, only in edit mode
    /*
    private void OnDrawGizmos()
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

    public GameObject GetMonster()
    {
        return monster;
    }
    public GameObject GetTreasure()
    {
        return treasure;
    }
}
