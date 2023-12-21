using System;
using System.Collections.Generic;
using System.Linq;

public class GameService : IGameService
{
    private readonly IGameRepository gameRepository;
    private readonly IPlayerRepository playerRepository;
    private readonly IPlayerService playerService;

    public GameService()
    {
        gameRepository = new GameRepository();
        playerRepository = new PlayerRepository();
        
    }

    public void PlayGame(int playerId1, int playerId2, string gameType, int gamePoints)
    {
      
            gameRepository.PlayGame(playerId1, playerId2, gameType, gamePoints);
        
    }


    public Game GetGameById(int gameIndex)
    {
        return gameRepository.ReadGameById(gameIndex);
    }

    public List<Game> GetAllGames()
    {
        return gameRepository.ReadAllGames();
    }

    public void UpdateGame(Game game)
    {
        gameRepository.UpdateGame(game);
    }

    public void DeleteGame(int gameIndex)
    {
        gameRepository.DeleteGame(gameIndex);
    }
    public List<Game> GetAllGamesForPlayer(string playerName)
    {
        return gameRepository.ReadAllGamesForPlayer(playerName);
    }


    public void ShowAllGames()
    {
        var games = GetAllGames();

        Console.WriteLine("List of All Games:");
        Console.WriteLine("-------------------------------------------------------------------------------------------------------");
        Console.WriteLine("| Game ID  | Player          | Opponent        | Game Type    | Result | Rating Change | Game Points  |");
        Console.WriteLine("-------------------------------------------------------------------------------------------------------");
        foreach (var game in games)
        {
            Console.WriteLine($"| {game.GameIndex,-8} |{game.PlayerName,-15}  | {game.OpponentName,-15} | {game.GameType,-12} | {(game.isWin ? "Win" : "Loss"),-6} | {game.CurrentRating,-13} | {game.GamePoints,-12} |");
        }
        Console.WriteLine("-------------------------------------------------------------------------------------------------------");


    }

    public void GameStatsForPlayer(string playerName)
    {
        var playerGames = GetAllGamesForPlayer(playerName);

        Console.WriteLine($"Game Statistics for Player: {playerName}");
        Console.WriteLine("-------------------------------------------------------------------------------------");
        Console.WriteLine("| Game ID  | Opponent        | Game Type    | Result | Rating Change | Game Points  |");
        Console.WriteLine("-------------------------------------------------------------------------------------");

        foreach (var game in playerGames)
        {
            Console.WriteLine($"| {game.GameIndex,-8} | {game.OpponentName,-15} | {game.GameType,-12} | {(game.isWin ? "Win" : "Loss"),-6} | {game.CurrentRating,-13} | {game.GamePoints,-12} |");
        }

        Console.WriteLine("-------------------------------------------------------------------------------------");
    }
}

