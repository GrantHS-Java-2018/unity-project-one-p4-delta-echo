using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

public class Die : MonoBehaviour
{
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public int Roll(int times)
    {
        int total = 0;
        for (int i = 0; i < times; i ++)
        {
            total += Random.Range(1, 6);
        }

        return total;
    }
}
