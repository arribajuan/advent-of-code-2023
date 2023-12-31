namespace Stars.Day05;

public class Day05Test
{
    
    [Fact]
    public void Test_Day05_FindLocationsForAlmanacSeeds_FromFile_Test()
    {
        var almanac = Day05.ParseAlmanacFromFile(Day05.GetFilePath(FileType.Test));
        var locations = Day05.FindLocationsForAlmanacSeeds(almanac, SeedType.Normal);
        var minLocation = locations.Min();
        
        Assert.Equal(35, minLocation);
    }
    
    public void Test_Day05_FindLocationsForAlmanacSeeds_FromFile_Challenge()
    {
        var almanac = Day05.ParseAlmanacFromFile(Day05.GetFilePath(FileType.ChallengeData));
        var locations = Day05.FindLocationsForAlmanacSeeds(almanac, SeedType.Normal);
        var minLocation = locations.Min();
        
        Assert.Equal(35, minLocation);
    }
    
    [Fact]
    public void Test_Day05_ParseAlmanac_FromFile_Test()
    {
        var almanac = Day05.ParseAlmanacFromFile(Day05.GetFilePath(FileType.Test));
        
        Assert.NotNull(almanac);

        Assert.NotNull(almanac.SeedArray);
        if (almanac.SeedArray != null)
        {
            Assert.NotEmpty(almanac.SeedArray);
        }

        Assert.NotNull(almanac.SeedToSoilMap);
        if (almanac.SeedToSoilMap != null)
        {
            Assert.NotEmpty(almanac.SeedToSoilMap);
            Assert.Equal(2, almanac.SeedToSoilMap.GetLength(0));
            Assert.Equal(3, almanac.SeedToSoilMap.GetLength(1));
        }
       
        Assert.NotNull(almanac.SoilToFertilizerMap);
        if (almanac.SoilToFertilizerMap != null)
        {
            Assert.NotEmpty(almanac.SoilToFertilizerMap);
            Assert.Equal(3, almanac.SoilToFertilizerMap.GetLength(0));
            Assert.Equal(3, almanac.SoilToFertilizerMap.GetLength(1));
        }
        
        Assert.NotNull(almanac.FertilizerToWaterMap);
        if (almanac.FertilizerToWaterMap != null)
        {
            Assert.NotEmpty(almanac.FertilizerToWaterMap);
            Assert.Equal(4, almanac.FertilizerToWaterMap.GetLength(0));
            Assert.Equal(3, almanac.FertilizerToWaterMap.GetLength(1));
        }
        
        Assert.NotNull(almanac.WaterToLightMap);
        if (almanac.WaterToLightMap != null)
        {
            Assert.NotEmpty(almanac.WaterToLightMap);
            Assert.Equal(2, almanac.WaterToLightMap.GetLength(0));
            Assert.Equal(3, almanac.WaterToLightMap.GetLength(1));
        }
        
        Assert.NotNull(almanac.LightToTemperatureMap);
        if (almanac.LightToTemperatureMap != null)
        {
            Assert.NotEmpty(almanac.LightToTemperatureMap);
            Assert.Equal(3, almanac.LightToTemperatureMap.GetLength(0));
            Assert.Equal(3, almanac.LightToTemperatureMap.GetLength(1));
        }

        Assert.NotNull(almanac.TemperatureToHumidityMap);
        if (almanac.TemperatureToHumidityMap != null)
        {
            Assert.NotEmpty(almanac.TemperatureToHumidityMap);
            Assert.Equal(2, almanac.TemperatureToHumidityMap.GetLength(0));
            Assert.Equal(3, almanac.TemperatureToHumidityMap.GetLength(1));
        }
        
        Assert.NotNull(almanac.HumidityToLocationMap);
        if (almanac.HumidityToLocationMap != null)
        {
            Assert.NotEmpty(almanac.HumidityToLocationMap);
            Assert.Equal(2, almanac.HumidityToLocationMap.GetLength(0));
            Assert.Equal(3, almanac.HumidityToLocationMap.GetLength(1));
        }
    }
    
    public void Test_Day05_ParseAlmanac_FromFile_Challenge()
    {
        var almanac = Day05.ParseAlmanacFromFile(Day05.GetFilePath(FileType.ChallengeData));
        
        Assert.NotNull(almanac);

        Assert.NotNull(almanac.SeedArray);
        if (almanac.SeedArray != null)
        {
            Assert.NotEmpty(almanac.SeedArray);
        }

        Assert.NotNull(almanac.SeedToSoilMap);
        if (almanac.SeedToSoilMap != null)
        {
            Assert.NotEmpty(almanac.SeedToSoilMap);
            Assert.Equal(47, almanac.SeedToSoilMap.GetLength(0));
            Assert.Equal(3, almanac.SeedToSoilMap.GetLength(1));
        }
       
        Assert.NotNull(almanac.SoilToFertilizerMap);
        if (almanac.SoilToFertilizerMap != null)
        {
            Assert.NotEmpty(almanac.SoilToFertilizerMap);
            Assert.Equal(18, almanac.SoilToFertilizerMap.GetLength(0));
            Assert.Equal(3, almanac.SoilToFertilizerMap.GetLength(1));
        }
        
        Assert.NotNull(almanac.FertilizerToWaterMap);
        if (almanac.FertilizerToWaterMap != null)
        {
            Assert.NotEmpty(almanac.FertilizerToWaterMap);
            Assert.Equal(12, almanac.FertilizerToWaterMap.GetLength(0));
            Assert.Equal(3, almanac.FertilizerToWaterMap.GetLength(1));
        }
        
        Assert.NotNull(almanac.WaterToLightMap);
        if (almanac.WaterToLightMap != null)
        {
            Assert.NotEmpty(almanac.WaterToLightMap);
            Assert.Equal(49, almanac.WaterToLightMap.GetLength(0));
            Assert.Equal(3, almanac.WaterToLightMap.GetLength(1));
        }
        
        Assert.NotNull(almanac.LightToTemperatureMap);
        if (almanac.LightToTemperatureMap != null)
        {
            Assert.NotEmpty(almanac.LightToTemperatureMap);
            Assert.Equal(30, almanac.LightToTemperatureMap.GetLength(0));
            Assert.Equal(3, almanac.LightToTemperatureMap.GetLength(1));
        }

        Assert.NotNull(almanac.TemperatureToHumidityMap);
        if (almanac.TemperatureToHumidityMap != null)
        {
            Assert.NotEmpty(almanac.TemperatureToHumidityMap);
            Assert.Equal(23, almanac.TemperatureToHumidityMap.GetLength(0));
            Assert.Equal(3, almanac.TemperatureToHumidityMap.GetLength(1));
        }
        
        Assert.NotNull(almanac.HumidityToLocationMap);
        if (almanac.HumidityToLocationMap != null)
        {
            Assert.NotEmpty(almanac.HumidityToLocationMap);
            Assert.Equal(43, almanac.HumidityToLocationMap.GetLength(0));
            Assert.Equal(3, almanac.HumidityToLocationMap.GetLength(1));
        }
    }
}