using System.Text;

namespace Helpers;

public class FileIO
{
    public List<string> LoadTextLinesFromFile(string fileLocation)
    {
        var result = new List<string>();

        if (File.Exists(fileLocation))
        {
            var fileLines = File.ReadAllLines(fileLocation, Encoding.Default);
            result.AddRange(fileLines);
        }

        return result;
    }
    
    public string LoadTextFromFile(string fileLocation)
    {
        var result = string.Empty;

        if (File.Exists(fileLocation))
        {
            var fileText = File.ReadAllText(fileLocation, Encoding.Default);
            result = fileText;
        }

        return result;
    }

    public string[,] Load2DArrayFromFile(string fileLocation)
    {
        var lines = LoadTextLinesFromFile(fileLocation);
        if (lines.Count == 0) return new string [0, 0];
        
        var result = new string[lines.Count, lines[0].Length];
        for (int i = 0; i < lines.Count; i++)
        {
            var line = lines[i].ToCharArray();
            for (int j = 0; j < line.GetLength(0); j++)
            {
                result[i, j] = line[j].ToString();
            }
        }
        
        return result;
    }
}