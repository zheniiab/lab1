using System.Collections.Generic;

public interface IPlayerRepository
{
    void CreatePlayer(Player player);
    Player ReadPlayerById(int playerId);
    List<Player> ReadAllPlayers();
    Player ReadPlayerByName(string playerName);
    void UpdatePlayer(Player player);
    void DeletePlayer(int playerId);
   
}