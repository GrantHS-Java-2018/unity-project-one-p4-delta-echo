using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    public GameObject playerPrefab;
    
    public List<GameObject> players = new List<GameObject>();
    
    void Start()
    {
        Debug.Log("Main initialized");
        AddPlayers();
        Debug.Log("Entering game loop");
        GameLoop();
    }
    
    private void AddPlayers()
    {
        
        /*
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
        */
        
        //Currently we just need three players, this is temporary
        Debug.Log("Instantiating players");
        for (int i = 0; i < 3; i++)
        {
            players.Add(Instantiate(playerPrefab, this.transform));
        }
        Debug.Log("Players instantiated");
    }

    //While no one has won, loop through players, moves current, then checks if anyone's won, in which case loop breaks.
    private void GameLoop()
    {
        bool win = false;
        Debug.Log("Entered game loop");
        while (!win)
        {
            for (int currentPlayer = 0; currentPlayer < 3 /*player count*/; currentPlayer ++)
            {
                Debug.Log("Attempting to move");
                Move(currentPlayer);
                Debug.Log("Completed move");
                
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
        
        /*
        //gives the elf an unfair advantage
        if (players[currentPlayer].GetComponent<Player>().GetClass() == 1)
        {
            moves++;
        }

        int tempVal = 0;
        
        //appears to give the poorest player a fair advantage
        if (players[currentPlayer].GetComponent<Player>().GetGold()/players[currentPlayer].GetComponent<Player>().GetWinAmount() >= 0.25) //maybe amend to just be player in last place
        for (int i = 0; i > players.Count; i++)
        {
            tempVal += players[i].GetComponent<Player>().GetGold() / players[i].GetComponent<Player>().GetWinAmount();
        }

        tempVal = tempVal / players.Count;
        
        if (players[currentPlayer].GetComponent<Player>().GetGold() / players[currentPlayer].GetComponent<Player>().GetWinAmount() >= tempVal)
        {
            moves++;
        } else if(players[currentPlayer].GetComponent<Player>().GetGold() / players[currentPlayer].GetComponent<Player>().GetWinAmount() <= tempVal*(players.Count-1))
        {
            moves--;
        }
        */
        
        Debug.Log("Entering movement loop");
        while (moves > 0)
        {
            Debug.Log("Calling Move() in Player");
            var moveSuccessful = players[currentPlayer].GetComponent<Player>().Move();
            
            if (moveSuccessful)
            {
                moves--;
            }
            Debug.Log("Move() successfully called in Player");
        }
    }
}
