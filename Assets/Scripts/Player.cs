﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using Random = UnityEngine.Random;

public class Player : MonoBehaviour
{
    public GameObject die;
    public GameObject movement;
    public GameObject currentNode;
    
    private int playerClass; //changed by class
    private int winAmount;
    private int loseATurn;
    private List<GameObject> treasures = new List<GameObject>();

    private int WinAmount
    {
        set
        {
            if (value == 3)
            {
                winAmount = 20000;
            }
            else if (value == 4)
            {
                winAmount = 30000;
            }
            else 
            {
                winAmount = 10000;
            }
        }
        get
        {
            return winAmount;
        }                                
    } //ditto

    private int gold = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Player initialized");
        Debug.Log("Instantiating player prefabs");
        Debug.Log("Player prefabs instantiated");
    }

    public void SetClass(int tempClass)
    {
        playerClass = tempClass;
        WinAmount = tempClass;
    }

    public bool Move()
    {
        Debug.Log("Attempting to detect node, calling DetectNode() in Movement");
        Debug.Log(movement);
        GameObject newNode = movement.GetComponent<Movement>().DetectNode(currentNode);
        Debug.Log("Successfully detected node");
        
        if (newNode != null)
        {
            Debug.Log("Moving to new node");
            this.transform.position = newNode.transform.position;
            currentNode = newNode;
            //OnEntry();
            
            Debug.Log("Move successful");
            return true;
        }
        
        return false;
    }

    /*
    public void OnEntry()
    {
        GameObject monster = currentNode.GetComponent<Waypoint>().GetMonster();
        if (monster != null)
        {
            Fight(monster);
        }
    }

    public void Fight(GameObject monster)
    {
        var result = monster.GetComponent<Monster>().Fight(die.GetComponent<Die>().Roll(2), playerClass);
        if (!result)
        {
            int total = die.GetComponent<Die>().Roll(2);
            if (total >= 5)//miss
            {
            }else if (total >= 7)//stunned
            {
                DropTreasure(0);
            }else if (total >=10)//wounded
            {
                loseATurn += 1;
                DropTreasure(1);

            }else if (total == 11)//seriously wounded
            {
                DropTreasure(2);

            }else if (total == 12)//killed
            {
                DropTreasure(3);
                Death();
            }
            else //error report
            {print("error"+total);
            }

        }else
        {
           treasures.Add(currentNode.GetComponent<Waypoint>().GetTreasure());
           monster = null;
        }
    }
    */

    public int GetGold()
    {
        return gold;
    }

    public int GetWinAmount()
    {
        return winAmount;
    }
    public int GetClass()
    {
        return playerClass;
    }

    /*
    private void DropTreasure(int quantity)
    {
        int length = treasures.Count;
        if (quantity == 1)
        {
            treasures.RemoveAt(Random.Range(1,length));
            
        }else if (quantity == 2)
        {
            for (int i=0; i>(length/2);i++) {
                treasures.RemoveAt(Random.Range(1,treasures.Count));
            }
        } else if (quantity == 3)
        {
                treasures.Clear();
        }
    }

    private void Death()
    {
        //do stuff
        DropTreasure(3);
        SetClass(Random.Range(1,4));
    }
    */
}
