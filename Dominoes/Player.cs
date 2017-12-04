using System;

public class Player
{
    public readonly string Name;
    public readonly string TeamName;
    private int score = 0;

    // need to address tiles in hand of player
    public Player(string name, string teamName = "Team 1")
    {
        Name = name;
        teamName = TeamName;
    }
    
    public void AddScore(int s)
    {
        score += s;
    }

    public int GetScore()
    {
        return score;
    }

    public override string ToString()
    {
        return $"{Name} : {score}";
    }
}
