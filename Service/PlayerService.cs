using System;
using System.Collections.Generic;
using System.Linq;

public class PlayerService : IPlayerService
{
    private readonly IPlayerRepository playerRepository;

    public PlayerService()
    {
        playerRepository = new PlayerRepository();
    }

    public Player CreatePlayer(string userName, int rating, string accountType)
    {
        var player = AccountFactory.CreateGameAccount(userName, rating, accountType);
        playerRepository.CreatePlayer(player);
        return player;
    }

    public Player GetPlayerById(int playerId)
    {
        return playerRepository.ReadPlayerById(playerId);
    }

    public List<Player> GetAllPlayers()
    {
        return playerRepository.ReadAllPlayers();
    }

    public void UpdatePlayer(Player player)
    {
        playerRepository.UpdatePlayer(player);
    }

    public void DeletePlayer(int playerId)
    {
        playerRepository.DeletePlayer(playerId);
    }
    public void ShowAllPlayers()
    {
        var players = GetAllPlayers();

        Console.WriteLine("\nList of all players:");
        Console.WriteLine("---------------------------------------------------------");
        Console.WriteLine("| Player ID | Username | Rating | Account Type          |");
        Console.WriteLine("---------------------------------------------------------");
        foreach (var player in players)
        {
            Console.WriteLine($"| {player.PlayerId,-10} | {player.UserName,-8} | {player.CurrentRating,-6} | {player.GetType().Name,-20} |");
        }
        Console.WriteLine("---------------------------------------------------------");


    }

    public void ShowPlayerRating(string playerName)
    {
        var player = GetPlayerById(GetPlayerIdByName(playerName));
        Console.WriteLine($"Current Rating for Player {playerName}: {player.CurrentRating}");
    }


    public int GetPlayerIdByName(string playerName)
    {
        var player = GetAllPlayers().FirstOrDefault(p => p.UserName == playerName);
       
           return player.PlayerId;
   
        
    }

}
