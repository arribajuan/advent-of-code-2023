using Microsoft.VisualBasic;

namespace Stars.Day04;

public class Day04
{
    public static int CalculatePointsInCardPileFromFile(string filePath)
    {
        var fio = new FileIO();
        var cardTextLines = fio.LoadTextLinesFromFile(filePath);

        var cardPile = new List<Card>();
        foreach (var cardText in cardTextLines)
        {
            cardPile.Add(ParseCard(cardText));
        }

        return cardPile.Sum(card => card.Points);
    }
    
    public static Card ParseCard(string cardText)
    {
        var newCard = new Card();
        
        var cardName = Strings.Trim(cardText.Substring(0, cardText.IndexOf(":")));
        var winningNumberString = Strings.Trim(cardText.Substring(cardText.IndexOf(":") + 1, cardText.IndexOf("|") -1 - cardText.IndexOf(":")));
        var yourNumberString = Strings.Trim(cardText.Substring(cardText.IndexOf("|") + 1, cardText.Length -1 - cardText.IndexOf("|")));

        newCard.CardName = cardName;
        
        var winningNumberStringArray = winningNumberString.Split(" ");
        foreach (var winningNumberStringItem in winningNumberStringArray)
        {
            if (winningNumberStringItem != "")
            {
                newCard.WinningNumbers.Add(int.Parse(winningNumberStringItem));
            }
        }

        var yourNumberStringArray = yourNumberString.Split(" ");
        foreach (var yourNumberStringItem in yourNumberStringArray)
        {
            if (yourNumberStringItem != "")
            {
                var yourNumberInt = int.Parse(yourNumberStringItem);
                newCard.YpurNumbers.Add(yourNumberInt);

                if (newCard.WinningNumbers.Contains(yourNumberInt))
                {
                    newCard.YourWinningNumbers.Add(yourNumberInt);
                }
            }
        }

        var points = 0;
        for (var i = 0; i < newCard.YourWinningNumbers.Count; i++)
        {
            if (points == 0)
            {
                points = 1;
            }
            else
            {
                points = points * 2;
            }
        }

        newCard.Points = points;
        
        Console.WriteLine(cardText);
        Console.WriteLine(cardName);
        Console.WriteLine(winningNumberString);
        Console.WriteLine(yourNumberString);
        Console.WriteLine(points);
        Console.WriteLine("");

        return newCard;
    }
    
    public static string GetFilePath(FileType fileType)
    {
        switch (fileType)
        {
            case FileType.ChallengeData:
                return AppDomain.CurrentDomain.BaseDirectory + "assets/data/day04-data.txt";;
            case FileType.Test:
                return AppDomain.CurrentDomain.BaseDirectory + "assets/data/day04-test.txt";;
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