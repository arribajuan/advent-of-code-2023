namespace Stars.Day03;

public class Day03
{
    public static List<SchematicNumber> FindSchematicNumbersInMatrixFromFile(string filePath)
    {
        var fio = new FileIO();
        var schematicMatrix = fio.Load2DArrayFromFile(filePath);

        return FindSchematicNumbersInMatrix(schematicMatrix);
    }

    public static List<SchematicNumber> FindSchematicNumbersInMatrix(string[,] schematicMatrix)
    {
        var result = new List<SchematicNumber>();
        
        for (var i = 0; i < schematicMatrix.GetLength(0); i++)
        {
            bool IsNumberHappening = false;
            int numberStart = 0;
            int numberLength = 0;
            var numberString = string.Empty;

            for (var j = 0; j < schematicMatrix.GetLength(1); j++)
            {
                var currentChar = schematicMatrix[i, j].ToCharArray()[0];   // lol, what a horrific thing to do
                if (char.IsNumber(currentChar)) 
                {
                    if (IsNumberHappening)
                    {
                        // continue number
                        numberString += currentChar;
                        numberLength++;
                    }
                    else
                    {
                        // start a new number
                        IsNumberHappening = true;
                        numberStart = i;
                        numberString = currentChar + "";
                        numberLength = 1;
                    }
                }
                else
                {
                    if (IsNumberHappening)
                    {
                        // finishing a number
                        
                        // Save to list
                        var newSchematicNumber = new SchematicNumber()
                        {
                            Row = i,
                            Start = numberStart,
                            Length = numberLength,
                            Number = int.Parse(numberString)
                        };
                        
                        newSchematicNumber.IsAdjacentToSymbol =
                            IsSymbolAdjacentToNumber(newSchematicNumber, schematicMatrix);
                        
                        result.Add(newSchematicNumber);
                        
                        Console.WriteLine(numberString);
                        
                        // cleanup
                        IsNumberHappening = false;
                        numberStart = 0;
                        numberString = string.Empty;
                        numberLength = 0;
                    }
                }
            }    
        }
        
        return result;
    }

    public static bool IsSymbolAdjacentToNumber(SchematicNumber number, string[,] schematicMatrix)
    {
        return false;
    }
    
    public static string GetFilePath(FileType fileType)
    {
        switch (fileType)
        {
            case FileType.ChallengeData:
                return AppDomain.CurrentDomain.BaseDirectory + "assets/data/day03-data.txt";;
            case FileType.Test:
                return AppDomain.CurrentDomain.BaseDirectory + "assets/data/day03-test.txt";;
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