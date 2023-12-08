using System.Collections.Concurrent;
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
        result.SeedArray = new long[seedTextArray.Length];
        for (var i = 0; i < result.SeedArray.Length; i++)
        {
            result.SeedArray[i] = Convert.ToInt64(seedTextArray[i]);
        }

        #endregion
        
        #region Parse extended seeds

        var extendedSeedList = new List<long>();
        for (var i = 0; i < result.SeedArray.Length; i = i + 2)
        {
            var seedStart = result.SeedArray[i];
            var seedEnd = seedStart + result.SeedArray[i + 1];

            for (var j = seedStart; j < seedEnd; j++)
            {
                extendedSeedList.Add(j);
            }
        }

        result.ExtendedSeedArray = extendedSeedList.ToArray();
        
        #endregion

        #region Parse sections
        
        var currentSection = string.Empty;
        var sectionLines = new List<string>();
        
        for(var i = 0; i < lineArray.Length; i++)
        {
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
        
        #region Parse correspondance
        
        result.SeedToSoilCorrespondances = ParseAlmanacCorespondanceMap(result.SeedToSoilMap);
        result.SoilToFertilizerCorrespondances = ParseAlmanacCorespondanceMap(result.SoilToFertilizerMap);
        result.FertilizerToWaterCorrespondances = ParseAlmanacCorespondanceMap(result.FertilizerToWaterMap);
        result.WaterToLightCorrespondances = ParseAlmanacCorespondanceMap(result.WaterToLightMap);
        result.LightToTemperatureCorrespondances = ParseAlmanacCorespondanceMap(result.LightToTemperatureMap);
        result.TemperatureToHumidityCorrespondances = ParseAlmanacCorespondanceMap(result.TemperatureToHumidityMap);
        result.HumidityToLocationCorrespondances = ParseAlmanacCorespondanceMap(result.HumidityToLocationMap);
        
        #endregion
        
        return result;
    }

    public static List<CorrespondanceMap> ParseAlmanacCorespondanceMap(long[,] correspondanceMap)
    {
        var result = new List<CorrespondanceMap>();

        for (var i = 0; i < correspondanceMap.GetLength(0); i++)
        {
            var destinationRangeStart = correspondanceMap[i, 0];
            var sourceRangeStart = correspondanceMap[i, 1];
            var rangeLength = correspondanceMap[i, 2];
            var destinationRangeEnd = destinationRangeStart + rangeLength;
            var sourceRangeEnd = sourceRangeStart + rangeLength;
            
            result.Add(new CorrespondanceMap()
            {
                SourceStart = sourceRangeStart, 
                SourceEnd = sourceRangeEnd,
                DestinationStart = destinationRangeStart, 
                DestinationEnd = destinationRangeEnd 
            });
        }

        return result;
    }

    public static long FindDestinationFromSourceInCorrespondanceMap(long source, List<CorrespondanceMap> correspondanceMaps)
    {
        foreach (var correspondanceMap in correspondanceMaps)
        {
            if (source >= correspondanceMap.SourceStart && source <= correspondanceMap.SourceEnd)
            {
                var difference = source - correspondanceMap.SourceStart;
                var destination = correspondanceMap.DestinationStart + difference;
                return destination;
            }
        }
        
        return source;
    }
    
    public static List<Correspondance> ParseAlmanacCorrespondance_DELETE(long[,] correspondanceMap)
    {
        var result = new List<Correspondance>();

        for (var i = 0; i < correspondanceMap.GetLength(0); i++)
        {
            var destinationRangeStart = correspondanceMap[i, 0];
            var sourceRangeStart = correspondanceMap[i, 1];
            var rangeLength = correspondanceMap[i, 2];

            for (var j = sourceRangeStart; j < sourceRangeStart + rangeLength; j++)
            {
                result.Add(new Correspondance()
                {
                    Source = j, Destination = destinationRangeStart + (j - sourceRangeStart) 
                });
            }
        }

        return result;
    }

    public static long FindDestinationFromSourceInCorrespondances_DELETE(long source, List<Correspondance> correspondances)
    {
        Console.Write($" - FindDestinationFromSourceInCorrespondances {source} - ");

        foreach (var correspondance in correspondances)
        {
            if (correspondance.Source == source)
            {
                Console.WriteLine(correspondance.Destination);
                return correspondance.Destination;
            }
        }
        
        Console.WriteLine(source);
        
        return source;
    }
    
    public static long[] FindLocationsForAlmanacSeeds(Almanac almanac, SeedType seedType)
    {
        
        Console.WriteLine("");
        Console.WriteLine("Start FindLocationsForAlmanacSeeds");
        
        long[] seeds;
        if (seedType == SeedType.Extended)
        {
            seeds = almanac.ExtendedSeedArray;
        }
        else
        {
            seeds = almanac.SeedArray;
        }


        /*
        var locationList = new ConcurrentBag<long>();

        var i = 0;
        var count = 0;
        
        Parallel.ForEach(seeds, seed =>
        {

            if (count > 1000000)
            {
                Console.WriteLine($"Seed: {i} of {seeds.Length} = {((double)i / (double)seeds.Length):P2}");
                count = 0;
            }
            i++;
            count++;
            
            var soil = FindDestinationFromSourceInCorrespondanceMap(seed, almanac.SeedToSoilCorrespondances);
            var fertilizer = FindDestinationFromSourceInCorrespondanceMap(soil, almanac.SoilToFertilizerCorrespondances);
            var water = FindDestinationFromSourceInCorrespondanceMap(fertilizer, almanac.FertilizerToWaterCorrespondances);
            var light = FindDestinationFromSourceInCorrespondanceMap(water, almanac.WaterToLightCorrespondances);
            var temperature = FindDestinationFromSourceInCorrespondanceMap(light, almanac.LightToTemperatureCorrespondances);
            var humidity = FindDestinationFromSourceInCorrespondanceMap(temperature, almanac.TemperatureToHumidityCorrespondances);
            var location = FindDestinationFromSourceInCorrespondanceMap(humidity, almanac.HumidityToLocationCorrespondances);

            //Console.WriteLine($" -> {seed} -> {soil} -> {fertilizer} -> {water} -> {light} -> {temperature} -> {humidity} -> {location}");
            
            locationList.Add(location);
        });
        */
        
        
        
        var locationList = new List<long>();
        
        var i = 0;
        var count = 0;
        
        foreach(long seed in seeds)
        {
            if (count > 1000000)
            {
                Console.WriteLine($"Seed: {i} of {seeds.Length} = {((double)i / (double)seeds.Length):P2}");
                count = 0;
            }
            i++;
            count++;
            
            var soil = FindDestinationFromSourceInCorrespondanceMap(seed, almanac.SeedToSoilCorrespondances);
            var fertilizer = FindDestinationFromSourceInCorrespondanceMap(soil, almanac.SoilToFertilizerCorrespondances);
            var water = FindDestinationFromSourceInCorrespondanceMap(fertilizer, almanac.FertilizerToWaterCorrespondances);
            var light = FindDestinationFromSourceInCorrespondanceMap(water, almanac.WaterToLightCorrespondances);
            var temperature = FindDestinationFromSourceInCorrespondanceMap(light, almanac.LightToTemperatureCorrespondances);
            var humidity = FindDestinationFromSourceInCorrespondanceMap(temperature, almanac.TemperatureToHumidityCorrespondances);
            var location = FindDestinationFromSourceInCorrespondanceMap(humidity, almanac.HumidityToLocationCorrespondances);

            //Console.WriteLine($" -> {seed} -> {soil} -> {fertilizer} -> {water} -> {light} -> {temperature} -> {humidity} -> {location}");
            
            locationList.Add(location);
        }
        
        
        /*
        var result = new long[seeds.Length];
        
        var count = 0;
        for (var i = 0; i < seeds.Length; i++)
        {
            if (count > 1000000)
            {
                Console.WriteLine($"Seed: {i} of {seeds.Length} = {(i / seeds.Length) * 100}%");
                count = 0;
            }
            count++;
            
            var seed = seeds[i];
            var soil = FindDestinationFromSourceInCorrespondanceMap(seed, almanac.SeedToSoilCorrespondances);
            var fertilizer = FindDestinationFromSourceInCorrespondanceMap(soil, almanac.SoilToFertilizerCorrespondances);
            var water = FindDestinationFromSourceInCorrespondanceMap(fertilizer, almanac.FertilizerToWaterCorrespondances);
            var light = FindDestinationFromSourceInCorrespondanceMap(water, almanac.WaterToLightCorrespondances);
            var temperature = FindDestinationFromSourceInCorrespondanceMap(light, almanac.LightToTemperatureCorrespondances);
            var humidity = FindDestinationFromSourceInCorrespondanceMap(temperature, almanac.TemperatureToHumidityCorrespondances);
            var location = FindDestinationFromSourceInCorrespondanceMap(humidity, almanac.HumidityToLocationCorrespondances);

            //Console.WriteLine($" -> {seed} -> {soil} -> {fertilizer} -> {water} -> {light} -> {temperature} -> {humidity} -> {location}");
            
            result[i] = location;
        }
        */

        return locationList.ToArray();
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

public enum SeedType
{
    Normal,
    Extended
}