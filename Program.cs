using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    private static IPlayerService playerService;
    private static IGameService gameService;

    static void Main()
    {

        playerService = new PlayerService();
        gameService = new GameService();

         playerService.CreatePlayer("Tom", 100, "Standard");
         playerService.CreatePlayer("Ann", 100, "Premium");
         playerService.CreatePlayer("Sam", 100, "Extrapoints");


        playerService.ShowAllPlayers();

        int playerId1 = playerService.GetPlayerIdByName("Tom");
        int playerId2 = playerService.GetPlayerIdByName("Ann");
        int playerId3 = playerService.GetPlayerIdByName("Sam");
        Console.WriteLine();

        gameService.PlayGame(playerId1, playerId2, "Standard", 50);
        gameService.PlayGame(playerId2, playerId3, "Training", 100);
        gameService.PlayGame(playerId3, playerId1, "Double", 100);
        gameService.PlayGame(playerId3, playerId1, "Standard", 100);
        gameService.PlayGame(playerId3, playerId2, "Double", 50);


        var allPlayers = playerService.GetAllPlayers();
        foreach (var player in allPlayers)
        {
            gameService.GameStatsForPlayer(player.UserName);
            playerService.ShowPlayerRating(player.UserName);
            Console.WriteLine();
        }

        gameService.ShowAllGames();


    }
    //static void Main()
    //{
    //    playerService = new PlayerService();
    //    gameService = new GameService();

    //    playerService.CreatePlayer("Tom", 100, "Standard");
    //    playerService.CreatePlayer("Ann", 100, "Premium");
    //    playerService.CreatePlayer("Sam", 100, "Extrapoints");

    //    playerService.ShowAllPlayers();
    //    Console.WriteLine();


    //    var allPlayers = playerService.GetAllPlayers();
    //    foreach (var player in allPlayers)
    //    {
    //        gameService.GameStatsForPlayer(player.UserName);
    //        playerService.ShowPlayerRating(player.UserName);
    //        Console.WriteLine();
    //    }

    //    gameService.ShowAllGames();
    //}
}