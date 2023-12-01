namespace Stars.Day01;

public class Day01
{
    public int FindCalibrationValue(string text)
    {
        var firstNumber = string.Empty;
        var lastNumber = string.Empty;

        for (int i = 0; i < text.Length; i++)
        {
            if (Char.IsNumber(text[i]))
            {
                firstNumber = text[i].ToString();
                break;
            }
        }
        
        for (int i = text.Length - 1; i >= 0; i--)
        {
            if (Char.IsNumber(text[i]))
            {
                lastNumber = text[i].ToString();
                break;
            }
        }

        var result = Convert.ToInt32(firstNumber + lastNumber);
        return result;
    }

    public int SumCalibrationValuesFromFile(string filePath)
    {
        var totalCalibrationValue = 0;
        
        var fio = new FileIO();
        var textLines = fio.LoadTextLinesFromFile(filePath);

        foreach (var textLine in textLines)
        {
            totalCalibrationValue += FindCalibrationValue(textLine);
        }

        return totalCalibrationValue;
    }

    public static string GetFilePath(FileType fileType)
    {
        var dataFilePath = string.Empty;

        switch (fileType)
        {
             case FileType.ChallengeData:
                 dataFilePath = AppDomain.CurrentDomain.BaseDirectory + "assets/data/day01-data.txt";;
                 break;
             case FileType.Test:
                 dataFilePath = AppDomain.CurrentDomain.BaseDirectory + "assets/data/day01-test.txt";;
                 break;
        }

        return dataFilePath;
    }
}

public enum FileType
{
    Test,
    ChallengeData
}