class ExtraPointsAccount : Player
{
    private int WinsCount;
    public ExtraPointsAccount(string userName, int rating) : base(userName, rating)
    {
    }

    public override void WinGame(Game game)
    {
        int ratingChange = game.CalculateRatingChange();

        if (++WinsCount % 3 == 0)
        {
            ratingChange += 30; 
        }
        
            CurrentRating += ratingChange;
            game.CurrentRating = ratingChange;
            game.isWin = true;
            
        
    }

    public override void LoseGame(Game game)
    {
       
        int ratingChange = game.CalculateRatingChange();

        CurrentRating -= ratingChange;
        game.isWin = false;
       
    }
}