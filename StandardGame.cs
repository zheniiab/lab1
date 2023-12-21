public class StandardGame : Game
{
    public StandardGame(string opponentName, string playerName, int rating) : base(opponentName, playerName, rating, "Standard", rating)
    {
    }

    public override int CalculateRatingChange()
    {
        return CurrentRating;
    }
}
