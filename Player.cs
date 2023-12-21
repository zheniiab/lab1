using System;
using System.Collections.Generic;

public abstract class Player
{
    public int PlayerId { get; set; }
    public static int IndexPlayer =1000;
    public string UserName { get; set; }
    private int currentRating;
    public int CurrentRating
    {
        get { return currentRating; }
        set
        {
            if (value < 1)
            {
                currentRating = 1;
            }
            else
            {
                currentRating = value;
            }
        }
    }
    
    public Player(string userName, int rating)
    {
        PlayerId = ++IndexPlayer;
        UserName = userName;
        CurrentRating = rating;
        
    }

    public abstract void WinGame(Game game);
    public abstract void LoseGame(Game game);

    
}
