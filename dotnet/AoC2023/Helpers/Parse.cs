namespace Helpers;

public class Parse
{
    public static string[,] Load2DArrayFromTextLinesDay3(List<string> lines)
    {
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
    
    public static string[,] Load2DArrayFromTextLinesDay5(List<string> lines)
    {
        if (lines.Count == 0) return new string [0, 0];
        
        var result = new string[lines.Count, lines[0].Trim().Split(" ").Length];
        for (var i = 0; i < lines.Count; i++)
        {
            var itemArray = lines[i].Trim().Split(" ");
            
            for (var j = 0; j < itemArray.Length; j++)
            {
                result[i, j] = itemArray[j].Trim();
            }
        }
        
        return result;
    }
}