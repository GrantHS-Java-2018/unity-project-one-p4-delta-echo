﻿using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject diePrefab;
    public GameObject movementPrefab;
    public GameObject playerSprite;
    
    GameObject die;
    GameObject movement;
    private GameObject sprite;
    
    private int playerClass; //changed by class
    private int winAmount;
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

    public string Move()
    {
        string detectedColor = movement.GetComponent<Movement>().Move();
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