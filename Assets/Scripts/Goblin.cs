using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin : Monster
{
    protected GameObject die;
    
    int[] dc = new int[6]; //all monster cards inherit from this
    
    // Start is called before the first frame update
    void Start()
    {
        dc[0] = 3;
        dc[1] = 4;
        dc[2] = 2;
        dc[3] = 5;
        dc[4] = 2;
        dc[5] = 6;
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
