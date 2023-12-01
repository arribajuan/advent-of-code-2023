namespace Stars.Day01;

public class Day01
{
    public int FindCalibrationValue(string text, bool includeWrittenNumbers)
    {
        var firstNumber = string.Empty;
        var lastNumber = string.Empty;

        for (var i = 0; i < text.Length; i++)
        {
            if (char.IsNumber(text[i]))
            {
                firstNumber = text[i].ToString();
                break;
            }

            if (includeWrittenNumbers)
            {
                var remainingText = text.Substring(i, text.Length - i);
                var numberFound = ReturnWrittenNumberInText(remainingText);
                if (numberFound > 0)
                {
                    firstNumber = numberFound.ToString();
                    break;
                }
            }
        }
        
        for (var i = text.Length - 1; i >= 0; i--)
        {
            if (char.IsNumber(text[i]))
            {
                lastNumber = text[i].ToString();
                break;
            }
            
            if (includeWrittenNumbers)
            {
                var remainingText = text.Substring(i, text.Length - i);
                var numberFound = ReturnWrittenNumberInText(remainingText);
                if (numberFound > 0)
                {
                    lastNumber = numberFound.ToString();
                    break;
                }
            }
        }

        var result = Convert.ToInt32(firstNumber + lastNumber);
        return result;
    }

    public int SumCalibrationValuesFromFile(string filePath, bool includeWrittenNumbers)
    {
        var totalCalibrationValue = 0;
        
        var fio = new FileIO();
        var textLines = fio.LoadTextLinesFromFile(filePath);

        foreach (var textLine in textLines)
        {
            totalCalibrationValue += FindCalibrationValue(textLine, includeWrittenNumbers);
        }

        return totalCalibrationValue;
    }

    public static string GetFilePath(FileType fileType)
    {
        switch (fileType)
        {
             case FileType.ChallengeData:
                 return AppDomain.CurrentDomain.BaseDirectory + "assets/data/day01-data.txt";;
             case FileType.Test:
                 return AppDomain.CurrentDomain.BaseDirectory + "assets/data/day01-test.txt";;
        }

        return string.Empty;
    }

    private int ReturnWrittenNumberInText(string text)
    {
        var subStringToCheck = string.Empty;
        if (text.Length >= 3)
        {
            subStringToCheck = text.Substring(0, 3);
            switch (subStringToCheck)
            {
                case "one":
                    return 1;
                case "two":
                    return 2;
                case "six":
                    return 6;
            }
        }
        if (text.Length >= 4)
        {
            subStringToCheck = text.Substring(0, 4);
            switch (subStringToCheck)
            {
                case "four":
                    return 4;
                case "five":
                    return 5;
                case "nine":
                    return 9;
            }
        }
        if (text.Length >= 5)
        {
            subStringToCheck = text.Substring(0, 5);
            switch (subStringToCheck)
            {
                case "three":
                    return 3;
                case "seven":
                    return 7;
                case "eight":
                    return 8;
            }
        }
        
        return 0;
    }
}

public enum FileType
{
    Test,
    ChallengeData
}