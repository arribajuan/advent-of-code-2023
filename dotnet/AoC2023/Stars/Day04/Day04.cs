using Microsoft.VisualBasic;

namespace Stars.Day04;

public class Day04
{
    public static int CalculateTotalCardsFromFile(string filePath)
    {
        var cardPile = ReadCardPileFromFile(filePath);
        var cardBunches = cardPile.Select(card => new CardBunch() { Card = card, Count = 1 }).ToList();

        for (var i = 0; i < cardBunches.Count; i++)
        {
            //Console.WriteLine($"Processing card: {cardBunches[i].Card.CardName} - {cardBunches[i].Card.YourWinningNumbers.Count} matching numbers - count = {cardBunches[i].Count} ");
            
            for (var j = 0; j < cardBunches[i].Card.YourWinningNumbers.Count; j++)
            {
                if ((i + j + 1 < cardBunches.Count))
                {
                    //Console.WriteLine($" +{cardBunches[i].Count} to {cardBunches[i + j + 1].Card.CardName}");

                    cardBunches[i + j + 1].Count += cardBunches[i].Count;
                }
            }
        }
        
        return cardBunches.Sum(cardBunches => cardBunches.Count);
    }
    
    public static int CalculatePointsInCardPileFromFile(string filePath)
    {
        var cardPile = ReadCardPileFromFile(filePath);

        return cardPile.Sum(card => card.Points);
    }

    public static List<Card> ReadCardPileFromFile(string filePath)
    {
        var fio = new FileIO();
        var cardTextLines = fio.LoadTextLinesFromFile(filePath);

        return cardTextLines.Select(cardText => ParseCard(cardText)).ToList();
    }
    
    public static Card ParseCard(string cardText)
    {
        var newCard = new Card();
        
        var cardName = Strings.Trim(cardText.Substring(0, cardText.IndexOf(":")));
        var winningNumberString = Strings.Trim(cardText.Substring(cardText.IndexOf(":") + 1, cardText.IndexOf("|") -1 - cardText.IndexOf(":")));
        var yourNumberString = Strings.Trim(cardText.Substring(cardText.IndexOf("|") + 1, cardText.Length -1 - cardText.IndexOf("|")));

        newCard.CardName = cardName;
        newCard.CardNumber = int.Parse(cardName.Replace("Card ", "").Trim());

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
        
        //Console.WriteLine(cardText);
        //Console.WriteLine(cardName + " - " + newCard.CardNumber);
        //Console.WriteLine(winningNumberString);
        //Console.WriteLine(yourNumberString);
        //Console.WriteLine(points);
        //Console.WriteLine("");

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