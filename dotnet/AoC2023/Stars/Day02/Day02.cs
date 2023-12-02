namespace Stars.Day02;

public static class Day02
{
    public static int FindSumOfPowerOfTheMinimumSetOfBallsFromFile(string filePath)
    {
        var fio = new FileIO();
        var textLines = fio.LoadTextLinesFromFile(filePath);

        return textLines.Select(ParseGame).Sum(game => game.PowerOfTheMinimumSetOfBalls);
    }
    
    public static int FindSumOfPossibleGameIdsFromFile(string filePath, GameBudget gameBudget)
    {
        var fio = new FileIO();
        var textLines = fio.LoadTextLinesFromFile(filePath);

        return textLines.Select(ParseGame).Where(game => IsGamePossible(game, gameBudget)).Sum(game => game.GameId);
    }
    
    public static bool IsGamePossible(Game game, GameBudget gameBudget)
    {
        if (game.MaxRedBallCount > gameBudget.AvailableRedBalls) return false;
        if (game.MaxGreenBallCount > gameBudget.AvailableGreenBalls) return false;
        if (game.MaxBlueBallCount > gameBudget.AvailableBlueBalls) return false;
        return true;
    }
    
    public static Game ParseGame(string gameText)
    {
        var result = new Game();
        
        result.GameId = int.Parse(gameText.Substring(5, gameText.IndexOf(":") - 5));

        var gameSetsString = gameText.Substring(gameText.IndexOf(":") + 2, gameText.Length - gameText.IndexOf(":") - 2);
        var gameSetStringArray = gameSetsString.Split("; ");
        foreach (var gameSetString in gameSetStringArray)
        {
            result.GameSets.Add(ParseSet(gameSetString));
        }
        
        result.MaxRedBallCount = result.GameSets.Max(x => x.RedBallTotal);
        result.MaxGreenBallCount = result.GameSets.Max(x => x.GreenBallTotal);
        result.MaxBlueBallCount = result.GameSets.Max(x => x.BlueBallTotal);
        result.PowerOfTheMinimumSetOfBalls = result.MaxRedBallCount * result.MaxGreenBallCount * result.MaxBlueBallCount;
        
        return result;
    }

    public static Set ParseSet(string setText)
    {
        var result = new Set();

        var setBallTextArray = setText.Split(", ");
        foreach (var ballText in setBallTextArray)
        {
            var ballCount = int.Parse(ballText.Split(" ")[0]);
            var ballColor = ballText.Split(" ")[1];

            switch (ballColor)
            {
                case "red":
                    result.RedBallTotal = ballCount;
                    break;
                case "green":
                    result.GreenBallTotal = ballCount;
                    break;
                case "blue":
                    result.BlueBallTotal = ballCount;
                    break;
            }
        }

        return result;
    }
    
    public static string GetFilePath(FileType fileType)
    {
        switch (fileType)
        {
            case FileType.ChallengeData:
                return AppDomain.CurrentDomain.BaseDirectory + "assets/data/day02-data.txt";;
            case FileType.Test:
                return AppDomain.CurrentDomain.BaseDirectory + "assets/data/day02-test.txt";;
            default:
                return string.Empty;
        }
    }
}

public enum FileType
{
    Test,
    ChallengeData
}