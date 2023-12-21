public abstract class Game
{
   
    public static int IndexGame = 1000;
    public int GameIndex { get; set; } 
    public string OpponentName { get; set; }
    public string PlayerName { get; set; }
    public bool isWin { get; set; }
    public int CurrentRating { get; set; }
    public string GameType { get; set; }
    public int GamePoints { get; set; }

    public Game(string opponentName, string playerName, int rating, string gameType, int gamePoints)
    {
        GameIndex = ++IndexGame; 
        OpponentName = opponentName;
        PlayerName = playerName;
        CurrentRating = rating;
        GameType = gameType;
        GamePoints = gamePoints;
    }

    public abstract int CalculateRatingChange();
}