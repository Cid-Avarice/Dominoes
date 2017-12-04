﻿using Dominoes;
using System;


public class Player1
{

    public readonly string name;
    public readonly string teamName;
    private int score = 0;
    public Tile[] hand = new Tile[7];

    // need to address tiles in hand of player
    public Player1(string name, string teamName = "Team 1")
    {
        // call user input and return values? 
    }
    
    public void AddScore(int s)
    {
        score += s;
    }

    public int GetScore()
    {
        return score;
    }

    public void AssignHand(Tile[] given)
    {
        hand = given;
    }

}
