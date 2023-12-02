namespace Stars.Day02;

public static class Day02
{
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
}