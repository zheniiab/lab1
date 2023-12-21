public class TrainingGame : Game
{
    public TrainingGame(string opponentName, string playerName, int rating) : base(opponentName, playerName, rating, "Training", rating)
    {
    }

    public override int CalculateRatingChange()
    {
        CurrentRating = 0;
        return 0;
    }
}