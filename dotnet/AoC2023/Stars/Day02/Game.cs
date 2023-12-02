namespace Stars.Day02;

public class Game
{
    public int GameId { get; set; }
    public int MaxRedBallCount { get; set; }
    public int MaxGreenBallCount { get; set; }
    public int MaxBlueBallCount { get; set; }
    
    public int PowerOfTheMinimumSetOfBalls { get; set; }
    
    public List<Set> GameSets { get; set; } = new();
}