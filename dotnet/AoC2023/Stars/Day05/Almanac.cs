namespace Stars.Day05;

public class Almanac
{
    public int[] SeedArray { get; set; }
    public int [,] SeedToSoilMap { get; set; }
    public int [,] SoilToFertilizerMap { get; set; }
    public int [,] FertilizerToWaterMap { get; set; }
    public int [,] WaterToLightMap { get; set; }
    public int [,] LightToTemperatureMap { get; set; }
    public int [,] TemperatureToHumidityMap { get; set; }
    public int [,] HumidityToLocationMap { get; set; }
}