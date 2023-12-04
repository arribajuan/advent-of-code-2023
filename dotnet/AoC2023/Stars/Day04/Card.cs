namespace Stars.Day04;

public class Card
{
    public int CardNumber { get; set; }
    public string CardName { get; set; }
    public List<int> WinningNumbers { get; set; } = new();
    public List<int> YpurNumbers { get; set; } = new();
    public List<int> YourWinningNumbers { get; set; } = new();
    public int Points { get; set; }
}