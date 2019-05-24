﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public List<GameObject> neighborPrefabs;
    public GameObject monsterPrefab;
    public GameObject treasurePrefab;
    
    private List<GameObject> neighbors;
    private GameObject monster;
    private GameObject treasure;

    private void Start()
    {
        Debug.Log("Waypoint initialized");
        Debug.Log("Instantiating neighbors:");
        foreach (var neighbor in neighborPrefabs)
        {
            neighbors.Add(Instantiate(neighbor, transform));
        }

        monster = Instantiate(monsterPrefab, transform);
        treasure = Instantiate(treasurePrefab, transform);
        Debug.Log("Neighbors instantiated");
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

    public List<GameObject> getNeighbors()
    {
        return neighbors;
    }

    //Draws lines on map, only in edit mode
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

    public GameObject GetMonster()
    {
        return monster;
    }
    public GameObject GetTreasure()
    {
        return treasure;
    }

}
