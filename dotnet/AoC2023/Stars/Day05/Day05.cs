namespace Stars.Day05;

public class Day05
{

    public static Almanac ParseAlmanacFromFile(string filePath)
    {
        return ParseAlmanacFromText("");
    }
    
    public static Almanac ParseAlmanacFromText(string almanacText)
    {
        return null;
    }
    
    public static string GetFilePath(FileType fileType)
    {
        switch (fileType)
        {
            case FileType.ChallengeData:
                return AppDomain.CurrentDomain.BaseDirectory + "assets/data/day05-data.txt";;
            case FileType.Test:
                return AppDomain.CurrentDomain.BaseDirectory + "assets/data/day05-test.txt";;
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