using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int playerClass; //changed by class
    private int winAmount;
    private int Win
    {
        set
        {
            if (value == 3)
            {
                winAmount = 2000;
            }
            else if (value == 4)
            {
                winAmount = 3000;
            }
            else 
            {
                winAmount = 1000;
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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void SetClass(int tempClass)
    {
        playerClass = tempClass;
        Win = tempClass;
    }

    public string Move()
    {
        return "#000000"; //returns whatever the color detector finds. Probably will reference a Move class, which wll reference ColorDetector.
    }

    public int GetGold()
    {
        return gold;
    }

    public int GetWinAmount()
    {
        return winAmount;
    }
}
