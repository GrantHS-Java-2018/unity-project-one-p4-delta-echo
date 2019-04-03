using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    int playerClass; //changed by class
    int win;
    int Win
    {
        set
        {
            if (value == 3)
            {
                win = 2000;
            }
            else if (value == 4)
            {
                win = 3000;
            }
            else 
            {
                win = 1000;
            }
        }
        get
        {
            return win;
        }
    } //ditto
    
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
}
