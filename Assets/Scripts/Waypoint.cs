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
        Debug.Log("Instantiating monsters");
        if (monsterPrefabs.Count == 1)
        {
            Debug.Log("1 monster slot");
            if (monsterPrefabs[0] != null)
            {
                Debug.Log("Room, 1 monster");
                monsters.Add(Instantiate(monsterPrefabs[0], transform));
                treasure = Instantiate(treasurePrefab, transform);
            }
            else
            {
                Debug.Log("Empty room or chamber");
            }
        }
        else if (monsterPrefabs.Count == 3)
        {
            Debug.Log("3 monster slots");
            foreach (var monster in monsterPrefabs)
            {
                if (monster != null)
                {
                    Debug.Log("Chamber");
                    monsters.Add(Instantiate(monster, transform));
                }
                else
                {
                    Debug.Log("Empty chamber");
                }
            }
        }
        else
        {
            Debug.Log("Irregular monster slot #");
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
