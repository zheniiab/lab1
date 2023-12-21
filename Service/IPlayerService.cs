using System.Collections.Generic;

public interface IPlayerService
{
    Player CreatePlayer(string userName, int rating, string accountType);
    Player GetPlayerById(int playerId);
    List<Player> GetAllPlayers();
    void UpdatePlayer(Player player);
    void DeletePlayer(int playerId);
    void ShowAllPlayers();
    void ShowPlayerRating(string playerName);
    int GetPlayerIdByName(string playerName);
}