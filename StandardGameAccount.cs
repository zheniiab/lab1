
using System;
using System.Security.AccessControl;

class StandardGameAccount : Player
{
    public StandardGameAccount(string userName, int rating) : base(userName, rating)
    {
        
    }

    public override void WinGame(Game game)
    {
        int ratingChange = game.CalculateRatingChange();
        if (ratingChange < 0)
        {
            throw new ArgumentException("Rating can`t be negative");
        }
        else
        {
            CurrentRating += ratingChange;
            game.CurrentRating = ratingChange;
            game.isWin = true;
           
        }
       
    }

    public override void LoseGame(Game game)
    {
        int ratingChange = game.CalculateRatingChange();
        if (ratingChange < 0)
        {
            throw new ArgumentException("Rating can`t be negative");
        }
        else
        {
            CurrentRating -= ratingChange;
            game.isWin = false;
            
        }
       
    }
}