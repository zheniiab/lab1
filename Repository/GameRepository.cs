using System.Collections.Generic;
using System.Linq;
using System;

public class GameRepository : IGameRepository
{
    private readonly DbContext dbContext;
    private readonly IPlayerRepository playerRepository;

    public GameRepository()
    {
        dbContext = new DbContext();
        playerRepository = new PlayerRepository();
    }

    public void CreateGame(Game gameWin, Game gameLose)
    {
        dbContext.Games.Add(gameWin);
        dbContext.Games.Add(gameLose);
    }
    public void PlayGame(int playerId1, int playerId2, string gameType, int gamePoints)
    {
        var player1 = ReadPlayerById(playerId1);
        var player2 = ReadPlayerById(playerId2);

        if (player1 != null && player2 != null)
        {
            var gameWin = GameFactory.CreateGame(gameType, player2, player1, gamePoints);
            player1.WinGame(gameWin);
            Game.IndexGame--;
            var gameLose = GameFactory.CreateGame(gameType, player1, player2, gamePoints);
            player2.LoseGame(gameLose);
            
            CreateGame(gameWin, gameLose);
        }
        else
        {
            Console.WriteLine("Failed to retrieve player information. Make sure the players are created.");
        }
    }
    public Player ReadPlayerById(int playerId)
    {
        try
        {
            // Assuming you have a DbSet<Player> in your DbContext
            var player = dbContext.Players.FirstOrDefault(p => p.PlayerId == playerId);

            return player;
        }
        catch (Exception ex)
        {
            // Handle exceptions (e.g., log or throw)
            Console.WriteLine($"Error reading player by ID: {ex.Message}");
            return null;
        }
    }

    public Game ReadGameById(int gameIndex)
    {
        return dbContext.Games.FirstOrDefault(g => g.GameIndex == gameIndex); 
    }

    public List<Game> ReadAllGames()
    {
        return dbContext.Games;
    }

    public void UpdateGame(Game game)
    {
        var existingGame = dbContext.Games.FirstOrDefault(g => g.GameIndex == game.GameIndex); 

        if (existingGame != null)
        {
            existingGame.OpponentName = game.OpponentName;
            existingGame.isWin = game.isWin;
            existingGame.CurrentRating = game.CurrentRating;
            existingGame.GameIndex = game.GameIndex;
            existingGame.GameType = game.GameType;
            existingGame.GamePoints = game.GamePoints;
        }
        else
        {
            throw new InvalidOperationException("Game not found");
        }
    }

    public void DeleteGame(int gameIndex)
    {
        var gameToRemove = dbContext.Games.FirstOrDefault(g => g.GameIndex == gameIndex); 

        if (gameToRemove != null)
        {
            dbContext.Games.Remove(gameToRemove);
        }
        else
        {
            throw new InvalidOperationException("Game not found");
        }
    }
    public void UpdateGameResult(int gameIndex, bool isWin)
    {
        var gameToUpdate = dbContext.Games.FirstOrDefault(g => g.GameIndex == gameIndex);

        if (gameToUpdate != null)
        {
            gameToUpdate.isWin = isWin;
        }
        else
        {
            throw new InvalidOperationException("Game not found");
        }
    }

    public List<Game> ReadAllGamesForPlayer(string playerName)
    {
        var playerGames = dbContext.Games
            .Where(g => (g.PlayerName == playerName && g.OpponentName != playerName))
            .GroupBy(g => g.GameIndex)
            .Select(group => group.First())
            .ToList();

        return playerGames;
    }
    public Player ReadPlayerByName(string playerName)
    {
        return dbContext.Players.FirstOrDefault(p => p.UserName == playerName);
    }
    
}