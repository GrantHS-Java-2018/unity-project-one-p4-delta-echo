using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using Random = UnityEngine.Random;

public class Player : MonoBehaviour
{
    public GameObject diePrefab;
    public GameObject movementPrefab;
    public GameObject currentNodeAssignment;
    
    GameObject die;
    GameObject movement;
    
    GameObject currentNode;
    
    private int playerClass; //changed by class
    private int winAmount;
    private int loseATurn;
    private List<GameObject> treasures;

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
        die = Instantiate(diePrefab, this.transform);
        movement = Instantiate(movementPrefab, this.transform);
        currentNode = Instantiate(currentNodeAssignment, this.transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void SetClass(int tempClass)
    {
        playerClass = tempClass;
        WinAmount = tempClass;
    }

    public bool Move()
    {
        GameObject newNode = movement.GetComponent<Movement>().DetectNode(currentNode);
        if (newNode != null)
        {
            this.transform.position = newNode.transform.position;
            currentNode = newNode;
            OnEntry();

            return true;
        }

        return false;
    }

    public void OnEntry()
    {
        GameObject monster = currentNode.GetComponent<Waypoint>().GetMonster();
        if (monster != null)
        {
            //do stuff
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
            else //problem solving
            {print("error"+total);
            }

        }else
        {
           treasures.Add(currentNode.GetComponent<Waypoint>().GetTreasure());
        }
    }

    public int GetGold()
    {
        return gold;
    }

    public int GetWinAmount()
    {
        return winAmount;
    }

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
}
