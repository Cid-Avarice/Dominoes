using System;

public class Player1
{
    public String name;
    public String teamName;
    private static int score = 0;

    // need to address tiles in hand of player
    public Player1(String name, String teamName = "team1")
    {
        // call user input and return values? 
    }

    
    public static void addScore(int s)
    {
        score = score + s;
    }
    public static int getScore()
    {
        return score;
    }
}
