using System;

class PremiumGameAccount :  Player
{
    public PremiumGameAccount(string userName, int rating) : base(userName, rating)
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
            ratingChange = ratingChange / 2;

            CurrentRating -= ratingChange;
            game.isWin = false;
            game.CurrentRating = ratingChange;
            
        }
      
    }
}