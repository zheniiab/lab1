using System.Collections.Generic;

public class DbContext
{
    public List<Player> Players { get; set; }
    public List<Game> Games { get; set; }

    public DbContext()
    {
        Players = new List<Player>();
        Games = new List<Game>();
    }
}
