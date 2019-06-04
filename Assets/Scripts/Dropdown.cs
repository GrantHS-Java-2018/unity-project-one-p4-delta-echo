using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dropdown : MonoBehaviour
{
    public Dropdown dropdown;
    private Text selection;
    
    // Start is called before the first frame update
    void Start()
    {
        dropdown = GetComponent<Dropdown>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
