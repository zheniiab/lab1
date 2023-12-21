using System.Collections.Generic;
using System.Linq;
using System;

public class PlayerRepository : IPlayerRepository
{
    private readonly DbContext dbContext;

    public PlayerRepository()
    {
        dbContext = new DbContext();
    }

    public void CreatePlayer(Player player)
    {
       
        dbContext.Players.Add(player);
        Console.WriteLine($"Players count after creation: {dbContext.Players.Count}");
    }
   
    public Player ReadPlayerByName(string playerName)
    {
        return dbContext.Players.FirstOrDefault(p => p.UserName == playerName);
    }

    public Player ReadPlayerById(int playerId)
    {

        return dbContext.Players.LastOrDefault(p => p.PlayerId == playerId);

       
    }

    public List<Player> ReadAllPlayers()
    {
        return dbContext.Players;
    }

    public void UpdatePlayer(Player player)
    {
        var existingPlayer = dbContext.Players.FirstOrDefault(p => p.PlayerId == player.PlayerId);

        if (existingPlayer != null)
        {
            existingPlayer.UserName = player.UserName;
            existingPlayer.CurrentRating = player.CurrentRating;
            
        }
        else
        {
            throw new InvalidOperationException("Player not found");
        }
    }

    public void DeletePlayer(int playerId)
    {
        var playerToRemove = dbContext.Players.FirstOrDefault(p => p.PlayerId == playerId);

        if (playerToRemove != null)
        {
            dbContext.Players.Remove(playerToRemove);
        }
        else
        {
            throw new InvalidOperationException("Player not found");
        }
    }

}