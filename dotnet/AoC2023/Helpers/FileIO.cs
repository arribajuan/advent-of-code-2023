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
}