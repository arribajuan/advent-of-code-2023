namespace Stars.Day04;

public class Day04
{
    public static int CalculatePointsInCardPileFromFile(string filePath)
    {


        return 0;
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