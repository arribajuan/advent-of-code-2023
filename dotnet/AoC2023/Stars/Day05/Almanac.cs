namespace Stars.Day05;

public class Almanac
{
    public long[] SeedArray { get; set; }

    public long[] ExtendedSeedArray { get; set; }
    
    public long [,] SeedToSoilMap { get; set; }
    public long [,] SoilToFertilizerMap { get; set; }
    public long [,] FertilizerToWaterMap { get; set; }
    public long [,] WaterToLightMap { get; set; }
    public long [,] LightToTemperatureMap { get; set; }
    public long [,] TemperatureToHumidityMap { get; set; }
    public long [,] HumidityToLocationMap { get; set; }

    public List<CorrespondanceMap> SeedToSoilCorrespondances { get; set; } = new();
    public List<CorrespondanceMap> SoilToFertilizerCorrespondances { get; set; } = new();
    public List<CorrespondanceMap> FertilizerToWaterCorrespondances { get; set; } = new();
    public List<CorrespondanceMap> WaterToLightCorrespondances { get; set; } = new();
    public List<CorrespondanceMap> LightToTemperatureCorrespondances { get; set; } = new();
    public List<CorrespondanceMap> TemperatureToHumidityCorrespondances { get; set; } = new();
    public List<CorrespondanceMap> HumidityToLocationCorrespondances { get; set; } = new();
}