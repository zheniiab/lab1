using System.Collections.Generic;

public interface IGameRepository
{
    void CreateGame(Game gameWin, Game gameLose);
    void PlayGame(int playerId1, int playerId2, string gameType, int gamePoints);
    void UpdateGameResult(int gameIndex, bool isWin);
    Game ReadGameById(int gameIndex); 
    List<Game> ReadAllGames();
    void UpdateGame(Game game);
    void DeleteGame(int gameIndex);
    List<Game> ReadAllGamesForPlayer(string playerName);
    Player ReadPlayerByName(string playerName);
    Player ReadPlayerById(int playerId);
}