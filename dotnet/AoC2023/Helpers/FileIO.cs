using System.Text;

namespace Helpers;

public class FileIO
{
    public static List<string> LoadTextLinesFromFile(string fileLocation)
    {
        if (!File.Exists(fileLocation)) return new List<string>();

        var fileLineArray = File.ReadAllLines(fileLocation, Encoding.Default);
        var result = new List<string>();
        result.AddRange(fileLineArray);
        return result;
    }
    
    public static string LoadTextFromFile(string fileLocation)
    {
        if (!File.Exists(fileLocation)) return string.Empty;
        
        return File.ReadAllText(fileLocation, Encoding.Default);;
    }

    public static string[,] Load2DArrayFromFileDay3(string fileLocation)
    {
        if (!File.Exists(fileLocation)) return new string[0,0];
        
        var lines = LoadTextLinesFromFile(fileLocation);
        return Parse.Load2DArrayFromTextLinesDay3(lines);;
    }
    
    public static string[,] Load2DArrayFromFileDay5(string fileLocation)
    {
        if (!File.Exists(fileLocation)) return new string[0,0];
        
        var lines = LoadTextLinesFromFile(fileLocation);
        return Parse.Load2DArrayFromTextLinesDay5(lines);;
    }
}