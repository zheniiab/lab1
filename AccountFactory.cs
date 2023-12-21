using System;

public static class AccountFactory
{
    public static Player CreateGameAccount(string userName, int rating, string accountType)
    {
        switch (accountType)
        {
            case "Standard":
                return new StandardGameAccount(userName, rating);
            case "Premium":
                return new PremiumGameAccount(userName, rating);
            case "Extrapoints":
                return new ExtraPointsAccount(userName, rating);
            default:
                throw new ArgumentException("Invalid account type");
        }
    }
}
