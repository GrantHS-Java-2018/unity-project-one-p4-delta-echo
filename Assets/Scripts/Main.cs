using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{

    public GameObject playerPrefab;
    public List<GameObject> players;
    // Start is called before the first frame update
    void Start()
    {
        AddPlayers();
        GameLoop();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void AddPlayers()
    {
        for (int i = 0; i < 5; i ++)
        {
            Console.WriteLine("Choose a class: ");
            Console.WriteLine("1: Elf: can't fight as well, good at finding secret doors, needs 10000 gp to win");
            Console.WriteLine("2: Hero: Can fight, needs 10000 gp to win");
            Console.WriteLine("3: Superhero: Can fight much better, needs 20000 gp to win");
            Console.WriteLine("4: Wizard: Has powerful spells, needs 30000 gp to win");
            if (i >= 2)
            {
                Console.WriteLine("0: no new players");
            }

            players.Add(Instantiate(playerPrefab, this.transform));
        }
    }

    private void GameLoop()
    {
        bool win = false;
        while (!win)
        {
            for (int i = 0; i < 4 /*player count*/; i++)
            {
                
                string detectedColor = players[i].Move();
                if (detectedColor.Equals("#idunno"))
                {
                    //get monster, fight it
                    //if win, treasure
                }

                if (Players[i].GetGold() >= Players[i].GetWinAmount())
                {
                    //win stuff
                    win = true;
                    Console.WriteLine("player "+i+" wins!");
                }
                
            }
        }
    }
}
