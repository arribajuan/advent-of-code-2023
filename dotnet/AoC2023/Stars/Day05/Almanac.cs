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

    public List<Correspondance> SeedToSoilCorrespondances { get; set; } = new();
    public List<Correspondance> SoilToFertilizerCorrespondances { get; set; } = new();
    public List<Correspondance> FertilizerToWaterCorrespondances { get; set; } = new();
    public List<Correspondance> WaterToLightCorrespondances { get; set; } = new();
    public List<Correspondance> LightToTemperatureCorrespondances { get; set; } = new();
    public List<Correspondance> TemperatureToHumidityCorrespondances { get; set; } = new();
    public List<Correspondance> HumidityToLocationCorrespondances { get; set; } = new();
}