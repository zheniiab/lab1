public class DoubleGame : Game
{
    public DoubleGame(string opponentName, string playerName, int rating) : base(opponentName, playerName, rating, "Double", rating)
    {
    }

    public override int CalculateRatingChange()
    {
        CurrentRating = CurrentRating * 2;
        return CurrentRating;
    }
}