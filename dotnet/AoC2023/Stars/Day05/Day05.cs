using System.ComponentModel;

namespace Stars.Day05;

public class Day05
{

    public static Almanac ParseAlmanacFromFile(string filePath)
    {
        var lines = FileIO.LoadTextLinesFromFile(filePath);
        
        return ParseAlmanacFromText(lines);
    }
    
    public static Almanac ParseAlmanacFromText(List<string> lines)
    {
        var result = new Almanac();
        var lineArray = lines.ToArray();

        #region Parse seeds
        
        var seedArrayText = lineArray[0][7..];
        var seedTextArray = seedArrayText.Split(" ");
        result.SeedArray = new int[seedTextArray.Length];
        for (var i = 0; i < result.SeedArray.Length; i++)
        {
            result.SeedArray[i] = Convert.ToInt32(seedTextArray[i]);
        }

        #endregion

        #region Parse sections
        
        var currentSection = string.Empty;
        var sectionLines = new List<string>();
        
        for(var i = 0; i < lineArray.Length; i++)
        {
            Console.WriteLine(lineArray[i]);
            
            if (lineArray[i].Contains(":"))
            {
                // Starting a new section
                currentSection = lineArray[i];
                sectionLines = new List<string>();
            }
            else if (lineArray[i] == "" || i == lineArray.Length-1)
            {
                // Finish a section
                if (i == lineArray.Length - 1)
                {
                    sectionLines.Add(lineArray[i]);
                }

                var section2DArray = Parse.Load2DArrayFromTextLinesDay5(sectionLines);

                switch (currentSection)
                {
                    case "seed-to-soil map:":
                        result.SeedToSoilMap = section2DArray;
                        break;
                    case "soil-to-fertilizer map:":
                        result.SoilToFertilizerMap = section2DArray;
                        break;
                    case "fertilizer-to-water map:":
                        result.FertilizerToWaterMap = section2DArray;
                        break;
                    case "water-to-light map:":
                        result.WaterToLightMap = section2DArray;
                        break;
                    case "light-to-temperature map:":
                        result.LightToTemperatureMap = section2DArray;
                        break;
                    case "temperature-to-humidity map:":
                        result.TemperatureToHumidityMap = section2DArray;
                        break;
                        
                    case "humidity-to-location map:":
                        result.HumidityToLocationMap = section2DArray;
                        break;
                }
            }
            else
            {
                // Add lines to current section
                sectionLines.Add(lineArray[i]);
            }
        }
        
        #endregion
        
        return result;
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