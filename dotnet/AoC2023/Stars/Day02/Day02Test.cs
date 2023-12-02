namespace Stars.Day02;

public class Day02Test
{
    [Theory]
    [InlineData("Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green", 1, 4, 2, 6, 48)]
    [InlineData("Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue", 2, 1, 3, 4, 12)]
    [InlineData("Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red", 3, 20, 13, 6, 1560)]
    [InlineData("Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red", 4, 14, 3, 15, 630)]
    [InlineData("Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green", 5, 6, 3, 2, 36)]
    public void Test_Day02_ParseGame(string gameText, int gameId, int maxRed, int maxGreen, int maxBlue, int powerOfTheMinimumSetOfBalls)
    {
        var game = Day02.ParseGame(gameText);
        Assert.Equal(gameId , game.GameId);
        Assert.Equal(maxRed , game.MaxRedBallCount);
        Assert.Equal(maxGreen , game.MaxGreenBallCount);
        Assert.Equal(maxBlue , game.MaxBlueBallCount);
        Assert.Equal(powerOfTheMinimumSetOfBalls , game.PowerOfTheMinimumSetOfBalls);
    }
    
    [Theory]
    [InlineData("3 blue, 4 red", 4, 0, 3)]
    [InlineData("1 red, 2 green, 6 blue", 1, 2, 6)]
    [InlineData("2 green", 0, 2, 0)]
    public void Test_Day02_ParseSet(string setText, int redCount, int greenCount, int blueCount)
    {
        var set = Day02.ParseSet(setText);
        Assert.Equal(redCount , set.RedBallTotal);
        Assert.Equal(greenCount , set.GreenBallTotal);
        Assert.Equal(blueCount , set.BlueBallTotal);
    }
    
    [Fact]
    public void Test_Day02_FindSumOfPossibleGameIds_FromFile_Star1()
    {
        var gameBudget = new Stars.Day02.GameBudget { AvailableRedBalls = 12, AvailableGreenBalls = 13, AvailableBlueBalls = 14 };
        var sumOfPossibleGameIds = Day02.FindSumOfPossibleGameIdsFromFile(Day02.GetFilePath(FileType.Test), gameBudget);
        
        Assert.Equal(8, sumOfPossibleGameIds);
    }
    
    [Fact]
    public void Test_Day02_FindSumOfPowerOfTheMinimumSetOfBalls_FromFile_Star2()
    {
        var gameBudget = new Stars.Day02.GameBudget { AvailableRedBalls = 12, AvailableGreenBalls = 13, AvailableBlueBalls = 14 };
        var sumOfPossibleGameIds = Day02.FindSumOfPowerOfTheMinimumSetOfBallsFromFile(Day02.GetFilePath(FileType.Test));
        
        Assert.Equal(2286, sumOfPossibleGameIds);
    }
}