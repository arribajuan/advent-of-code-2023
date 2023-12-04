namespace Stars.Day03;

public class Day03
{
    public static int FindSumOfPartNumbersFromFile(string filePath)
    {
        var schematicNumbers = FindSchematicNumbersInMatrixFromFile(filePath);
        
        return schematicNumbers.Where(number => number.IsAdjacentToSymbol).Sum(number => number.Number);
    }
    
    public static List<SchematicNumber> FindSchematicNumbersInMatrixFromFile(string filePath)
    {
        var fio = new FileIO();
        var schematicMatrix = fio.Load2DArrayFromFile(filePath);
        var schematicNumbers = FindSchematicNumbersInMatrix(schematicMatrix);

        if (false)
        {
            foreach (var number in schematicNumbers)
            {
                Console.WriteLine(
                    $"Number = {number.Number}, {number.Row}.{number.Start}-{number.End}, TL={number.BoundaryTopRow}.{number.BoundaryLeft}-{number.BoundaryRight}, BR={number.BoundaryBottomRow}.{number.BoundaryLeft}-{number.BoundaryRight}, Is part number? {number.IsAdjacentToSymbol}");

                for (var i = number.BoundaryTopRow; i <= number.BoundaryBottomRow; i++)
                {
                    for (var j = number.BoundaryLeft; j <= number.BoundaryRight; j++)
                    {
                        var numberText = schematicMatrix[i, j];
                        Console.Write(numberText);
                    }

                    Console.WriteLine("");
                }
            }

            Console.WriteLine("");
        }

        return schematicNumbers;
    }

    private static List<SchematicNumber> FindSchematicNumbersInMatrix(string[,] schematicMatrix)
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
                    #region IsNumber
                    
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
                        numberStart = j;
                        numberString = currentChar + "";
                        numberLength = 1;
                    }
                    
                    #endregion
                    
                    #region Is end of row

                    if (j == schematicMatrix.GetLength(1) - 1)
                    {
                        if (IsNumberHappening)
                        {
                            #region finishing a number

                            // Save to list
                            var newSchematicNumber = new SchematicNumber()
                            {
                                Row = i,
                                Start = numberStart,
                                End = numberStart + numberLength - 1,  // it is inclusive  
                                Number = int.Parse(numberString)
                            };

                            result.Add(FillInTheBlanks(newSchematicNumber, schematicMatrix));

                            // cleanup
                            IsNumberHappening = false;
                            numberStart = 0;
                            numberString = string.Empty;
                            numberLength = 0;

                            #endregion
                        }
                    }

                    #endregion
                }
                else
                {
                    if (IsNumberHappening)
                    {
                        #region finishing a number
                        
                        // Save to list
                        var newSchematicNumber = new SchematicNumber()
                        {
                            Row = i,
                            Start = numberStart,
                            End = numberStart + numberLength - 1,  // it is inclusive  
                            Number = int.Parse(numberString)
                        };
                        
                        result.Add(FillInTheBlanks(newSchematicNumber, schematicMatrix));
                        
                        // cleanup
                        IsNumberHappening = false;
                        numberStart = 0;
                        numberString = string.Empty;
                        numberLength = 0;
                        
                        #endregion
                    }    
                }
            }    
        }
        
        return result;
    }

    private static SchematicNumber FillInTheBlanks(SchematicNumber number, string[,] schematicMatrix)
    {
        #region Find boundary
        
        if (number.Row == 0)
        {
            number.BoundaryTopRow = number.Row;
        }
        else
        {
            number.BoundaryTopRow = number.Row - 1;
        }
                        
        if (number.Start == 0)
        {
            number.BoundaryLeft = number.Start;
        }
        else
        {
            number.BoundaryLeft = number.Start - 1;
        }

        if (number.End == schematicMatrix.GetLength(1) -1)
        {
            number.BoundaryRight = number.End;
        }
        else
        {
            number.BoundaryRight = number.End + 1;
        }
        
        if (number.Row == schematicMatrix.GetLength(0) - 1)
        {
            number.BoundaryBottomRow = number.Row;
        }
        else
        {
            number.BoundaryBottomRow = number.Row + 1;
        }

        #endregion
        
        #region Determine if the number is adjacent to a symbol
        
        number.IsAdjacentToSymbol = false;
        for (var i = number.BoundaryTopRow; i <= number.BoundaryBottomRow; i++)
        {
            for (var j = number.BoundaryLeft; j <= number.BoundaryRight; j++)
            {
                var numberText = schematicMatrix[i, j];
                var currentChar = numberText.ToCharArray()[0];

                if (!char.IsNumber(currentChar) && currentChar != '.')
                {
                    number.IsAdjacentToSymbol = true;
                }
            }
        }
        
        #endregion
        
        return number;
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