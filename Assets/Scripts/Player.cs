using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject diePrefab;
    public GameObject movementPrefab;
    public Waypoint currentNodeAssignment;
    
    GameObject die;
    GameObject movement;
    Waypoint currentNode;
    
    private int playerClass; //changed by class
    private int winAmount;
    private int loseATurn;

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
        Waypoint newNode = movement.GetComponent<Movement>().DetectNode(currentNode);
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
        if (result)
        {
            int total = die.GetComponent<Die>().Roll(2);
            if (total >= 5)// miss
            {
            }else if (total >= 7)//stunned
            {
                dropTreasure(1);
            }else if (total >=10)//wounded
            {
                loseATurn += 1;
                dropTreasure(2);

            }else if (total == 11)//seriously wounded
            {
            }else if (total == 12)//killed
            {
            }
            else
            {print("error"+total);
            }

            //do stuff: 2-5 miss,6-7 stunned,8-10 wounded, 11 seriously wounded, 12
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

    private void dropTreasure(int quantity)
    {
        //quantity 0=stun, 1=wound, 2=serious
        //do stuff
    }
}
