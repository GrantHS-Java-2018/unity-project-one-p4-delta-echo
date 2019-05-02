﻿using System;
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
        for (int i = 0; i < 8; i ++)
        {
            Console.WriteLine("Choose a class: ");
            Console.WriteLine("1: Elf: Not very strong, good at finding secret doors, needs 10000 gp to win");
            Console.WriteLine("2: Hero: Can fight well, needs 10000 gp to win");
            Console.WriteLine("3: Superhero: The best fighter, needs 20000 gp to win");
            Console.WriteLine("4: Wizard: Has powerful spells, such as lightning bolt and fireball, needs 30000 gp to win");
            if (i >= 2)
            {
                Console.WriteLine("0: No new players");
            }

            players.Add(Instantiate(playerPrefab, this.transform));
        }
    }

    //While no one has won, loop through players, moves current, then checks if anyone's won, in which case loop breaks.
    private void GameLoop()
    {
        bool win = false;
        while (!win)
        {
            for (int currentPlayer = 0; currentPlayer < 4 /*player count*/; currentPlayer ++)
            {
                Move(currentPlayer);
                
                if (players[currentPlayer].GetComponent<Player>().GetGold() >= players[currentPlayer].GetComponent<Player>().GetWinAmount())
                {
                    //win stuff
                    win = true;
                    Console.WriteLine("player " + currentPlayer + " wins!");
                }
                
            }
        }
    }

    //Loops repeatedly until current player moves successfully, then counts down, 5 successful moves allowed
    private void Move(int currentPlayer)
    {
        int moves = 5;
        while (moves > 0)
        {
            var moveSuccessful = players[currentPlayer].GetComponent<Player>().Move();
            if (moveSuccessful)
            {
                moves--;
            }
        }
    }
}
