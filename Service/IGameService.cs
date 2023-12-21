using System.Collections.Generic;

public interface IGameService
{
    void PlayGame(int playerId1, int playerId2, string gameType, int gamePoints);
    Game GetGameById(int gameIndex);
    List<Game> GetAllGames();
    void UpdateGame(Game game);
    void DeleteGame(int gameIndex);
    List<Game> GetAllGamesForPlayer(string playerName);
    void ShowAllGames();
    void GameStatsForPlayer(string playerName);
}