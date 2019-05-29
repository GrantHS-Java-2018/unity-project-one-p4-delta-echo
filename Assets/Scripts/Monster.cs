using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Monster : MonoBehaviour
{
    public GameObject diePrefab;

    protected GameObject die;
    
    protected int[] dc = new int[6]; //all monster cards inherit from this
    
    // Start is called before the first frame update
    void Start()
    {
        die = Instantiate(diePrefab, this.transform);
    }

    public bool Fight(int roll, int character)
    {
        return roll >= dc[character];
    }
}
