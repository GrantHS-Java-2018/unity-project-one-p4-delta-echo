﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Monster : MonoBehaviour
{
    protected new GameObject Die;
    
    int[] dc = new int[6]; //all monster cards inherit from this
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool Fight(int roll, int character)
    {
        return roll >= dc[character];
    }
}
