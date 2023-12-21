public class GameFactory
{
    public static Game CreateGame(string type, Player player1, Player player2, int points)
    {
        if (type == "Standard")
        {
            return new StandardGame(player2.UserName, player1.UserName, points);
        }
        if (type == "Training")
        {
            return new TrainingGame(player2.UserName, player1.UserName, points);
        }
        if (type == "Double")
        {
            return new DoubleGame(player2.UserName, player1.UserName, points);
        }
        return null;
    }
}
